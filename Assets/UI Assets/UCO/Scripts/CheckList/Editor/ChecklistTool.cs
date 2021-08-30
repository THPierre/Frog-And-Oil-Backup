//Tim Maytom 2016
//Check out https://github.com/maytim/Unity-Check-List/tree/master to contribute improvements or ideas
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace Tools
{
    public class ChecklistTool : EditorWindow
    {
        //The Checklist data variables
        private List<CheckList.Entry> mylist;
        private string newItem = "";

        //The Checklist GUI variables
        private Vector2 scroll;
        private bool activeFoldout = true;
        private bool completeFoldout = true;

        //Action Queue to manage changes to the Entry list outside of OnGUI()
        private Queue<System.Action> guiEvents = new Queue<System.Action>();

        public CheckList checkListData;

        //Checklist constructor that initializes the data in the entry List
        public ChecklistTool()
        {

        }

        public void Initialize()
        {
            CheckList[] checkListSO = GetAllInstances<CheckList>();

            if (checkListSO.Length==1)
            {
                checkListData = checkListSO[0];
                if(!string.IsNullOrEmpty(checkListData.itemsJson))
                    mylist = JsonUtility.FromJson<CheckList.EntryListWrapper>(checkListData.itemsJson).list;
                else
                    mylist = new List<CheckList.Entry>();
            }
            else
            {
                Debug.LogWarning("CheckList data not found");
                mylist = new List<CheckList.Entry>();

                mylist.Add(new CheckList.Entry(false, "Sample entry."));
            }
        }

        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name); 
            T[] a = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return a;
        }

        //Note the '%&#_c' is used to create a shortcut for the Checklist
        [MenuItem("Window/Checklist %&#_c")]
        static void OpenChecklistTool()
        {
            ChecklistTool window = EditorWindow.GetWindow<ChecklistTool>(false);
            window.minSize = new Vector2(350, 200);
            GUIContent title = new GUIContent("Checklist");
            window.titleContent = title;
            window.Initialize();
        }

        void OnGUI()
        {
            //Check for 'Enter' key being pressed in the new item TextArea to add that item to the Entry list
            if (Event.current.isKey && GUI.GetNameOfFocusedControl() == "newTextArea")
            {
                switch (Event.current.keyCode)
                {
                    case KeyCode.Return:
                    case KeyCode.KeypadEnter:
                        if (newItem.Length > 0)
                        {
                            guiEvents.Enqueue(() =>
                            {
                                mylist.Add(new CheckList.Entry(false, newItem));
                                newItem = "";

                            });
                        }
                        break;
                }
            }

            scroll = EditorGUILayout.BeginScrollView(scroll, false, false);

            //Split the Tasks between Active and Complete Foldouts for better organization
            activeFoldout = EditorGUILayout.Foldout(activeFoldout, "Active");

            if (activeFoldout)
            {
                DisplayActiveTasks();
            }

            completeFoldout = EditorGUILayout.Foldout(completeFoldout, "Complete");

            if (completeFoldout)
            {
                DisplayFinishedTasks();
            }

            if(checkListData!=null && checkListData.allowEditing)
                DisplayNewEntry();

            GUILayout.EndScrollView();

        }

        void Update()
        {
            while (guiEvents.Count > 0)
            {
                guiEvents.Dequeue().Invoke();
            }
        }

        void OnFocus()
        {
            if(checkListData!=null)
                mylist = JsonUtility.FromJson<CheckList.EntryListWrapper>(checkListData.itemsJson).list;
        }

        void OnLostFocus()
        {
            CheckList.EntryListWrapper w;
            w.list = mylist;
            checkListData.itemsJson = JsonUtility.ToJson(w);
        }

        void OnDestroy()
        {
            CheckList.EntryListWrapper w;
            w.list = mylist;
            checkListData.itemsJson = JsonUtility.ToJson(w);
        }

        private void DisplayFinishedTasks()
        {
            foreach (CheckList.Entry e in mylist.ToArray())
            {
                if (e.complete)
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        e.complete = EditorGUILayout.Toggle(e.complete, GUILayout.MaxWidth(10));
                        EditorGUILayout.LabelField(StrikeThrough(e.text), GUILayout.MinWidth(300));
                        if (checkListData != null && checkListData.allowEditing)
                        {
                            if (GUILayout.Button("X", EditorStyles.miniButton, GUILayout.MaxWidth(20)))
                            {
                                var entryCopy = e;
                                guiEvents.Enqueue(() =>
                                {
                                    mylist.Remove(entryCopy);
                                });
                            }
                        }
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();
                }
            }
        }

        private void DisplayActiveTasks()
        {
            foreach (CheckList.Entry e in mylist.ToArray())
            {
                if (!e.complete)
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        e.complete = EditorGUILayout.Toggle(e.complete, GUILayout.MaxWidth(12));
                        e.text = GUILayout.TextArea(e.text, 300, GUILayout.MinWidth(300));
                        if (checkListData != null && checkListData.allowEditing)
                        {
                            if (GUILayout.Button("X", EditorStyles.miniButton, GUILayout.MaxWidth(20)))
                            {
                                var entryCopy = e;
                                guiEvents.Enqueue(() =>
                                {
                                    mylist.Remove(entryCopy);
                                });
                            }
                        }
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();
                }
            }
        }

        private void DisplayNewEntry()
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                GUILayout.Space(18);
                GUI.SetNextControlName("newTextArea");
                newItem = GUILayout.TextArea(newItem, 300, GUILayout.MinWidth(200));
                newItem = newItem.Replace("\n", "");

                if (GUILayout.Button("+", EditorStyles.miniButton, GUILayout.MaxWidth(20)))
                {
                    if (newItem.Length > 0)
                    {
                        guiEvents.Enqueue(() =>
                        {
                            mylist.Add(new CheckList.Entry(false, newItem));
                            newItem = "";
                        });
                    }
                }
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        //Helper method to covert regular unicode text into strikethrough text
        public string StrikeThrough(string s)
        {
            string strikethrough = "";
            foreach (char c in s)
            {
                strikethrough = strikethrough + c + '\u0336';
            }
            return strikethrough;
        }
    }
}
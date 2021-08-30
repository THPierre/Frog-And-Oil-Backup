using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    //[CreateAssetMenu(fileName = "CheckListData", menuName = "UCO/CheckListData", order = 1)]
    public class CheckList : ScriptableObject
    {
        [System.Serializable]
        public class Entry
        {
            public bool complete;
            public string text;

            public Entry()
            {
                complete = false;
                text = "";
            }

            public Entry(bool b, string s)
            {
                complete = b;
                text = s;
            }
        }

        //A wrapper for the Entry class to allow JsonUtility to stringify a list of Entry objects
        [System.Serializable]
        public struct EntryListWrapper
        {
            public List<Entry> list;
        }

        [HideInInspector]
        public string itemsJson;
        public bool allowEditing;
    }
}

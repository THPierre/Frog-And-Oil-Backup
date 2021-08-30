using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExportWindow : EditorWindow
{
    public static string studentName = "";
    public static string studentID = "";
    public static ExportProperties exportProperties;

    void OnGUI()
    {
        studentName = EditorGUILayout.TextField("Etudiant (NOM Prénom):", studentName);

        GUI.enabled = !string.IsNullOrEmpty(studentName.Trim());
        if (GUILayout.Button("Exporter"))
        {
            exportProperties.studentName = studentName;
            studentID = studentName.Replace(" ", "_");
            studentID = studentID.Replace("é", "e");
            studentID = studentID.Replace("è", "e");
            ExportAllAssets();
            Close();
        }
        GUI.enabled = true;

        if (GUILayout.Button("Annuler"))
            Close();
    }

    [MenuItem("UCO/Exporter")]
    static void ShowNamePopup()
    {
        ExportWindow window = new ExportWindow();
        string[] assets = AssetDatabase.FindAssets("ExportProperties t:ExportProperties", new[] { "Assets/UCO" });
        if (assets.Length > 0)
        {
            Debug.Log(AssetDatabase.GUIDToAssetPath(assets[0]));
            exportProperties = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(assets[0]), typeof(ExportProperties)) as ExportProperties;
            studentName = exportProperties.studentName;
        }
            
        window.ShowUtility();
    }

    static void ExportAllAssets()
    {
        string[] projectContent = AssetDatabase.GetAllAssetPaths();
        List<string> contentToExport = new List<string>();
        for (int i = 0; i < projectContent.Length; i++)
        {
            if (projectContent[i].StartsWith("Assets") || projectContent[i].StartsWith("ProjectSettings"))
            {
                contentToExport.Add(projectContent[i]);
            }
        }

        AssetDatabase.ExportPackage(contentToExport.ToArray(), exportProperties.GetProjectID() + studentID + ".unitypackage", ExportPackageOptions.Interactive | ExportPackageOptions.Default);//.Recurse | ExportPackageOptions.IncludeLibraryAssets);

        Debug.Log("Project Exported");
    }
}
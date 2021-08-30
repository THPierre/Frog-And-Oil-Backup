using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "ExportProperties", menuName = "UCO/ExportProperties", order = 1)]
public class ExportProperties : ScriptableObject
{
    public string studentName = "";
    public enum Grade
    {
        L1, L2, L3
    }
    public Grade grade;
    public int unitID = 0;
    public enum ProjectType
    {
        Proto, Exo, Eval
    }
    public ProjectType projectType;

    public string GetProjectID()
    {
        return "[" + grade.ToString() + "U" + unitID + "][" + projectType + "]";
    }
}
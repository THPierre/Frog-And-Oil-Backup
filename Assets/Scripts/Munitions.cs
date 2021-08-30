using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Munitions", menuName = "ScriptableObjects/Munitions", order = 1)]
public class Munitions : ScriptableObject
{
    public string id;
    public GameObject bullet;
    public float coolDownTime;


    public bool Mode;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] tuiles;
    public Vector3 spawnPos;
    public void CallaTuile()
    {
        Instantiate(tuiles[Random.Range(0, tuiles.Length)], spawnPos , tuiles[1].transform.rotation );
        
    }


}

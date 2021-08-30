using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualSpawn : MonoBehaviour
{
    public GameObject defaultEnemiePrefab;

    private void Update()
   {
        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < 5 ; i++)
           {
                GameObject obj = Instantiate(defaultEnemiePrefab );
                obj.transform.position = new Vector3(0, 0, 0);
            }
        }
    }
}


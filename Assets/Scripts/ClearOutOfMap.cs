using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearOutOfMap : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject)
        {

            Destroy(other.gameObject);
        }
    }
}

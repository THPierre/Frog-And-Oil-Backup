using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            Destroy(this.gameObject);
    }
}

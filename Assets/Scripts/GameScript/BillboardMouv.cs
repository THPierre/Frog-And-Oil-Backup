using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardMouv : MonoBehaviour
{
    public float speed;
    private BackgroundManager managerScript;
    public float coordonate;

    private void Start()
    {
        managerScript = GameObject.Find("BackgroundManager").GetComponent(typeof(BackgroundManager)) as BackgroundManager;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.z <coordonate)
        {
            managerScript.CallaTuile();
            Debug.Log("La tuile à atteind l'endroit voulu");
            Destroy(gameObject);
        }
    }
}


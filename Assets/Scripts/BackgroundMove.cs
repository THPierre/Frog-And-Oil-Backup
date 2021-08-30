using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed;
    private BackgroundManager managerScript;

    private void Start()
    {
        managerScript = GameObject.Find("BackgroundManager").GetComponent(typeof(BackgroundManager)) as BackgroundManager;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.z < -25)
        {
            managerScript.CallaTuile();
            Debug.Log("La tuile à atteind l'endroit voulu");
            Destroy(gameObject);
        }
    }
}

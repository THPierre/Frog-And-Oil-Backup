using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    
    public float speed;

    private Vector3 startPos;
    
    // Start is called before the first frame update
    private void Start()
    {
       
        startPos = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.z < startPos.z - 20)
        {
            transform.position = startPos;
        }
    }
}

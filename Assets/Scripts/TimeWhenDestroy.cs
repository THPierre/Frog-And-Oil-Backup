using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWhenDestroy : MonoBehaviour
{
    public float timeTravel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TravelTime());
    }

    IEnumerator TravelTime()

    {
        yield return new WaitForSeconds(timeTravel);
        Destroy(this.gameObject);
    }
}

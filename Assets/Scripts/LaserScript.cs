using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public int LaserDamage;
    public bool collided;
    public GameObject Player;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(TravelTime());

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collided = true;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collided = false;
        }
    }


    public void Update()
    {
        if (collided)
        {
            Health_Player health = Player.gameObject.GetComponent<Health_Player>();
            if (health != null)
            health.Damage(LaserDamage *Time.deltaTime);
        }

    }

    IEnumerator TravelTime()

    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}

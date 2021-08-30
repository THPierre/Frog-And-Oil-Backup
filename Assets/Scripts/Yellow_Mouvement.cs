using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Mouvement : MonoBehaviour
{
    public GameObject munitions;

    public float speed;

    public float maximumZPos;

    private Transform player;

    public float nextBurstTime;


    public float shootSpaceWhenWasShoot;
    public float shootHeightWhenWasShoot;
    public AudioSource insectshot;

    private void Start()
    {
        insectshot = GameObject.Find("EnemyShot").GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(player.transform.position);

        NewMethod();



    }

    private void NewMethod()
    {
        if (transform.position.z < maximumZPos)
            transform.position = new Vector3(transform.position.x, transform.position.y, maximumZPos);
    }



    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(nextBurstTime);

        insectshot.Play();

        Instantiate(munitions, new Vector3(transform.position.x, transform.position.y + shootHeightWhenWasShoot, transform.position.z + shootSpaceWhenWasShoot), transform.rotation);

        yield return StartCoroutine(Shoot());



    }
}
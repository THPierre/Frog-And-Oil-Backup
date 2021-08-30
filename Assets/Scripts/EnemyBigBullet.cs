using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigBullet : MonoBehaviour
{
    public List<Munitions> munitions;
    public int chosenMunition;

    public float speed;

    public float maximumZPos;

    private Transform player;

    public float nextBurstTime;
    public float nextFireTime;

    public float shootSpaceWhenWasShoot;
    public float shootHeightWhenWasShoot;
    public AudioSource insectshot;

    private void Start()
    {
        insectshot = GameObject.Find("EnemyShot").GetComponent<AudioSource>();
        //player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //transform.LookAt(player.transform.position);

        NewMethod();



    }

    private void NewMethod()
    {
        if (transform.position.z < maximumZPos)
            transform.position = new Vector3(transform.position.x, transform.position.y, maximumZPos);
    }



    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(nextBurstTime);

        print("Shoot");
        yield return new WaitForSeconds(nextFireTime);

        insectshot.Play();
        Instantiate(munitions[chosenMunition].bullet, new Vector3(transform.position.x, transform.position.y + shootHeightWhenWasShoot, transform.position.z + shootSpaceWhenWasShoot), transform.rotation);
       

        yield return StartCoroutine(Shoot());



    }
}

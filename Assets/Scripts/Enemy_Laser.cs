using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Laser : MonoBehaviour
{
    public GameObject munitions;
    public GameObject laserChargefx;

    public float speed;
    private bool Oncharge;

    public float maximumZPos;

    private Transform player;

    public float nextBurstTime;
    public float timeWhileHeFlies;

    public float shootSpaceWhenWasShoot;
    public float shootHeightWhenWasShoot;

    public float chargeSpace;
    public AudioSource laserchargefx;
    public AudioSource laserfirefx;

    private void Start()
    {
        laserchargefx = GameObject.Find("lasercharge").GetComponent<AudioSource>();
        laserfirefx = GameObject.Find("laserfire").GetComponent<AudioSource>();
        //player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (Oncharge == false)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //transform.LookAt(player.transform.position);
        }
        KeepEnemyAwayFromPlayerZone();



    }

    private void KeepEnemyAwayFromPlayerZone()
    {
        if (transform.position.z < maximumZPos)
            transform.position = new Vector3(transform.position.x, transform.position.y, maximumZPos);
    }



    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeWhileHeFlies);
        Oncharge = true;
        laserchargefx.Play();
        Instantiate(laserChargefx, new Vector3(transform.position.x, transform.position.y + shootHeightWhenWasShoot, transform.position.z + chargeSpace), transform.rotation);
        yield return new WaitForSeconds(nextBurstTime);
        laserfirefx.Play();
        Instantiate(munitions, new Vector3(transform.position.x, transform.position.y + shootHeightWhenWasShoot, transform.position.z + shootSpaceWhenWasShoot), transform.rotation);

        yield return new WaitForSeconds(5);

        Oncharge = false;
        yield return StartCoroutine(Shoot());



    }
}

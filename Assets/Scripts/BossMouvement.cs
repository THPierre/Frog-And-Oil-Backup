using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouvement : MonoBehaviour
{
    public List<Munitions> munitions;
    public int chosenMunition;

    public float firstnextBurstTime;
    public float firstnextFireTime;

    public float secondnextBurstTime;


    private Transform player;

    public float shootSpaceWhenWasShoot;
    public float shootHeightWhenWasShoot;
    public float shootRightWhenWasShoot;

    public float laserSpace;
    public float laserHeight;

    private Transform laserDirection;
    private Transform laserCharge;

    public GameObject laserChargefx;
    public AudioSource basicBulletSound;
    public AudioSource laserChargeSound;
    public AudioSource laserFireSound;
    

    public float timeWhileHeFlies;
    private bool Oncharge;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        laserDirection = GameObject.FindWithTag("LaserDirection").transform;
        laserCharge = GameObject.FindWithTag("LaserCharge").transform;
        StartCoroutine(FirstShoot());
    }
    private void Update()
    {
        if (Oncharge == false)
        {
            transform.LookAt(player.transform.position);
        }
    }


    private IEnumerator FirstShoot()
    {
        if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
        {
            StopCoroutine(FirstShoot());
        }
            
            //if (gameObject.GetComponent<Health_Boss>().healthPoints > 1)
        //{
            yield return new WaitForSeconds(firstnextBurstTime);
            chosenMunition = 0;

            yield return new WaitForSeconds(firstnextFireTime);
        //if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            basicBulletSound.Play();
        //if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            Instantiate(munitions[chosenMunition].bullet, new Vector3(transform.position.x + shootRightWhenWasShoot, transform.position.y + shootHeightWhenWasShoot, transform.position.z + shootSpaceWhenWasShoot), transform.rotation);
            yield return new WaitForSeconds(firstnextFireTime);
       // if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            basicBulletSound.Play();
        Instantiate(munitions[chosenMunition].bullet, new Vector3(transform.position.x + shootRightWhenWasShoot, transform.position.y + shootHeightWhenWasShoot, transform.position.z + shootSpaceWhenWasShoot), transform.rotation);
            yield return new WaitForSeconds(firstnextFireTime);
      //  if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            basicBulletSound.Play();
       // if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            Instantiate(munitions[chosenMunition].bullet, new Vector3(transform.position.x + shootRightWhenWasShoot, transform.position.y + shootHeightWhenWasShoot, transform.position.z + shootSpaceWhenWasShoot), transform.rotation);
        
       // if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            yield return StartCoroutine(SecondShoot());
        
        yield return null;
    }
    private IEnumerator SecondShoot()
    {
        if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
        {
            StopCoroutine(SecondShoot());
        }
                chosenMunition = 1;
                yield return new WaitForSeconds(timeWhileHeFlies);
                Oncharge = true;
        if (gameObject.GetComponent<Health_Boss>().healthPoints >= 1)
        {
            laserChargeSound.Play();
            //  if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            Instantiate(laserChargefx, new Vector3(laserCharge.transform.position.x, laserCharge.transform.position.y, laserCharge.transform.position.z), laserChargefx.transform.rotation);
            yield return new WaitForSeconds(secondnextBurstTime);
            //  if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            laserFireSound.Play();
            // if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            Instantiate(munitions[chosenMunition].bullet, new Vector3(laserDirection.transform.position.x, laserDirection.transform.position.y, laserDirection.transform.position.z), laserDirection.transform.rotation);
        }
                yield return new WaitForSeconds(4);

                Oncharge = false;
       // if (gameObject.GetComponent<Health_Boss>().healthPoints < 1)
            yield return StartCoroutine(FirstShoot());

        

    }
}

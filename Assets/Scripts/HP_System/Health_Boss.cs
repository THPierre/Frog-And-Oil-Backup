using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Boss : MonoBehaviour
{
    public int healthPoints;
    public GameObject explosionFx;
    LevelLoader youWinloader;
    public SkinnedMeshRenderer bossMesh;
    AudioSource bossDeathSound;
    public GameObject laserFirefX;
    public GameObject laserChargeFx;

    private void Start()
    {
        bossDeathSound = GameObject.Find("bossDeath").GetComponent<AudioSource>();
        youWinloader = GameObject.Find("Main Camera").GetComponent<LevelLoader>();
    }
    public IEnumerator RecoveryTime()
    {
        //damageFx.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;

        yield return null;
    }

    public void Damage(int damagesToApply)
    {
        healthPoints -= damagesToApply;
        Debug.Log("Hit");
        if(healthPoints >= 1)
        StartCoroutine(RecoveryTime());
        if (healthPoints < 1)
        {
            BossMouvement bossMouv = gameObject.GetComponent<BossMouvement>();
            bossMouv.basicBulletSound.enabled = false;
            bossMouv.laserChargeSound.enabled = false;
            bossMouv.laserFireSound.enabled = false;
            //laserChargeFx.GetComponent<SpriteRenderer>().enabled = false;
            laserFirefX.GetComponentInChildren<SpriteRenderer>().enabled = false;
            laserFirefX.GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(Destroy());
        }
    }

    public IEnumerator Destroy()
    {
        bossDeathSound.Play();
       //BossMouvement bossMouv = gameObject.GetComponent<BossMouvement>();
       // bossMouv.basicBulletSound.enabled = false;
       // bossMouv.laserChargeSound.enabled = false;
        //bossMouv.laserFireSound.enabled = false;
        //laserChargeFx.GetComponent<SpriteRenderer>().enabled = false;
        //laserFirefX.GetComponentInChildren<SpriteRenderer>().enabled = false;
        //laserFirefX.GetComponentInChildren<SpriteRenderer>().enabled = false;
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        StartCoroutine(youWinloader.YouWinTransition());
        yield return new WaitForSeconds(0.5f);
        //Destroy(this.gameObject);
        bossMesh.enabled = false;
        yield return null;
    }

    
}
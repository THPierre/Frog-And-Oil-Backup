using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int healthPoints;
    public WaveManager waveManage;
    public GameObject explosionFx;
    private AudioSource deathFx;


    public void Start()
    {
        deathFx = GameObject.Find("PlayerDeath").GetComponent<AudioSource>();
        waveManage = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }

    public IEnumerator RecoveryTime()
    {
        //damageFx.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>() .enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;

        yield return null;
    }

    public void Damage(int damagesToApply)
    {
        healthPoints -= damagesToApply;
        if(healthPoints >= 1)
        StartCoroutine(RecoveryTime());
        if (healthPoints < 1)
        {
            waveManage.enemiesLeft -= 1;

            Destroy();
        }
    }

    public virtual void Destroy()
    {
        Debug.Log("oOOf");
           deathFx.Play();
        Instantiate(explosionFx, transform.position + new Vector3(0,2.8f,0) , explosionFx.transform.rotation);
        
        Destroy(this.gameObject);


    }
}
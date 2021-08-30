using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints;
    public  WaveManager waveManage;
    public GameObject explosionFx;


    public void Start()
    {
        waveManage = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }

    
    public void Damage(int damagesToApply)
    {
        healthPoints -= damagesToApply;
        Debug.Log("Hit");
        if (healthPoints < 1)
        {
            waveManage.enemiesLeft -= 1;

            Destroy();
        }
    }

    public virtual void Destroy()
    {
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        Destroy(this.gameObject);
        
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public Animator FrogAnim; //Modif Anim
    public AudioSource shotFx;

    public List <Munitions> munitions;

    private float nextFireTime = 0;
    public int chosenMunition;
    public float bulletYpos;
    public float bulletZpos;

    private void Start()
    {
        chosenMunition = 0;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(GameManager.gameManager.Fire))
            {
                FrogAnim.SetTrigger("Shoot"); //Modif ANim
                shotFx.Play();
                Instantiate(munitions[chosenMunition].bullet, new Vector3 (transform.position.x,transform.position.y+ bulletYpos, transform.position.z+bulletZpos), transform.rotation);
                nextFireTime = Time.time + munitions[chosenMunition].coolDownTime;
            }
        }
    }


 
}

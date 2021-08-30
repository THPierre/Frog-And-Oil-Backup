using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouvement : MonoBehaviour
{
    public List<Munitions> munitions;
    public int chosenMunition;

    private Rigidbody enemyRb;
    public float movespeed;
    public float rotateSpeed;

    public float reach;
    


    private float nextFireTime = 0;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    { 

            enemyRb.velocity = (transform.forward * movespeed *Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);

        Debug.DrawRay(transform.position, transform.forward * reach, Color.red);

        OnReach();

    }

    private void OnReach()
    {
        RaycastHit hit;

        var fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, reach) && hit.transform.tag == "Player")
        {
            RotateAroundPlayer();
            Shoot();
        }
    }

    void RotateAroundPlayer()
    {
        transform.RotateAround(player.transform.position,
        new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            
           
                Instantiate(munitions[chosenMunition].bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
                nextFireTime = Time.time + munitions[chosenMunition].coolDownTime;
         
        }
    }
}

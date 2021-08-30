using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpille : MonoBehaviour
{
    public float speed;
    private Rigidbody TorpilleRb;



    public float SphereRadius;
    public float maxDistance;
    public LayerMask layerMask;


    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

    public string TagTarget;

    public int BulletDamage;


    // Start is called before the first frame update
    void Start()
    {
        TorpilleRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        origin = transform.position;
        direction = transform.position;

        RaycastHit hit;

        if(Physics.SphereCast(origin, SphereRadius, direction,out hit, maxDistance,layerMask ,QueryTriggerInteraction.UseGlobal) && hit.transform.tag == "Enemy")
        {
            print(hit.transform + "est détécté");

            Vector3 torpillePlayerVector = hit.transform.position - transform.position;
            Vector3 torpillePlayerDirection = torpillePlayerVector.normalized;
            TorpilleRb.AddForce(torpillePlayerDirection * speed);

            

            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, torpillePlayerDirection, 5 * Time.deltaTime, 0.0F));
        }

     
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }

    private void OnTriggerEnter(Collider collision)
    {
       
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
                health.Damage(BulletDamage);
            Destroy(this.gameObject);
        }
    }


}

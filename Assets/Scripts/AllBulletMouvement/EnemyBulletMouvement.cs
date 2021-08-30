using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMouvement : MonoBehaviour
{
    public float bulletspeed;
    public int BulletDamage;
    public float timeTravel;

    private void Start()
    {
        StartCoroutine(TravelTime());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletspeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Health_Player health = collision.gameObject.GetComponent<Health_Player>();
        if (health != null)
            health.Damage(BulletDamage);

        Destroy(this.gameObject);
    }

    IEnumerator TravelTime()

    {
        yield return new WaitForSeconds(timeTravel);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Animator FrogAnim; //Anim Modif
    public float speed;

    private float horizontalInput;
    private float verticalInput;

    public float borderZtop;
    public float borderZbot;
    public float borderXleft;
    public float borderXright;

    private Rigidbody PlayerRB;
    public PlayerGetDirection Boss;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        Boss = FindObjectOfType<PlayerGetDirection>();
    }

    void Update()
    {
        if (Input.GetKeyDown("a"))//modif Anim
        {  //modif Anim
            FrogAnim.SetTrigger("Jump"); //modif Anim
        }  //modif Anim
        Move();

        KeepPlayerInArea();

        transform.LookAt(Boss.transform);
    }

    private void KeepPlayerInArea()
    {
        if (transform.position.x < borderXleft)
            transform.position = new Vector3(borderXleft, transform.position.y, transform.position.z);

        if (transform.position.x > borderXright)
            transform.position = new Vector3(borderXright, transform.position.y, transform.position.z);


        if (transform.position.z < borderZbot)
            transform.position = new Vector3(transform.position.x, transform.position.y, borderZbot);

        if (transform.position.z > borderZtop)
            transform.position = new Vector3(transform.position.x, transform.position.y, borderZtop);

        Debug.DrawLine(new Vector3(borderXleft,1,borderZtop), transform.forward, Color.red);
        Debug.DrawLine(new Vector3(borderXright, 1, borderZtop), transform.right, Color.red);
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
}

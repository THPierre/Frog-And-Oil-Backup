using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPlayerMouvement : MonoBehaviour
{
    public Animator FrogAnim;
    public float Horizontalspeed;
    public float Verticalspeed;

    private float horizontalInput;
    private float verticalInput;

    public float borderZtop;
    public float borderZbot;
    public float borderXleft;
    public float borderXright;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float jumpCoolDown;
    private float nextJumpTime = 0;
    GameManager gameManager;

    public float groudPosition;

    Rigidbody rb;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void Update()
    {

        {
            if (Input.GetKeyDown("x")) //Modif ANim
            { //Modif ANim

                FrogAnim.SetTrigger("Jump");
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                nextJumpTime = Time.time + jumpCoolDown;
                 //Modif ANim
                
            } //Modif ANim
        }


        KeepPlayerOnGround();

        Move();

        KeepPlayerInArea();

    }

    private void KeepPlayerOnGround()
    {
        if (transform.position.y < 0.75)
            transform.position = new Vector3(transform.position.x, groudPosition, transform.position.z);
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
    }

    private void Move()
    {
        if (Input.GetKey(gameManager.MoveForward))
        transform.Translate(Vector3.forward * Time.deltaTime * Verticalspeed);
        if (Input.GetKey(gameManager.MoveBackward))
        transform.Translate(Vector3.back * Time.deltaTime * Verticalspeed);
        if (Input.GetKey(gameManager.MoveLeft))
        transform.Translate(Vector3.left * Time.deltaTime * Verticalspeed);
        if (Input.GetKey(gameManager.MoveRight))
        transform.Translate(Vector3.right * Time.deltaTime * Verticalspeed);
    }
}

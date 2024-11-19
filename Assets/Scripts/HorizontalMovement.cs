using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [Header("References")]

    private Rigidbody2D rb2D;

    private Animator animator;

    [Header("Movemente")]

    [SerializeField] private float moveVelocity; //Speed

    [Header("Jump")]

    [SerializeField] private float jumpForce;

    [SerializeField] private Transform groundController;

    [SerializeField] private Vector2 boxDimensions;

    [SerializeField] private LayerMask whatsGround;



    private bool inGround;      //detector of ground
    private bool jump;          //strenght of jump
    private float lastShoot;    //time before another bullet
   // private int Health = 3;     //life of avatar


    public GameObject BulletPrefab; //prefab of bullet attributes
    public bool canMove = true;

    [SerializeField] private Vector2 bounceSpeed; //rebote

    private void Start()                    //indicators to put objects
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    
    private void Update()
    {
       
        
        if (Input.GetButtonDown("Jump"))            //jump by key
        {
            jump = true;            
        }
        
        inGround = Physics2D.OverlapBox(groundController.position, boxDimensions, 0, whatsGround); //detector of ground
        animator.SetBool("inGround", inGround);
        
        
        
        
        if (Input.GetKey(KeyCode.C) && Time.time>  lastShoot+0.35f)
        {
            shoot();                //calls functionf bullet
            lastShoot = Time.time;  //time before another attack
        }

    }
    private void Move()
    {
        rb2D.velocity = new Vector2(moveVelocity, rb2D.velocity.y);
    }
    private void FixedUpdate()
    {
        if (jump && inGround)       //confirm the state of ground
        {
            Jump();
            //inGround = false;
            //rb2D.AddForce(new Vector2(0f, jumpForce));
        }

        if(canMove)
        {
            Move();
        }

        jump = false;
    }

    private void Jump()
    {
        rb2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
        inGround = false;
        jump = false;

    }
    
    
    private void OnDrawGizmosSelected()  //draws a line to feel the gound
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundController.position, boxDimensions);
    }

    private void shoot()
    {

        Vector3 direction;
        if (transform.localScale.x == 1f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position-direction*1f, Quaternion.identity); //instant part of shooting iniciate at front part of player
        bullet.GetComponent<Bulletscript>().SetDirection(direction);
    }

    //public void Hit()           //what happens if it touched
    //{
    //    Health = Health - 1;

    //    if (Health == 0) Destroy(gameObject);
    //}

    public void bounce (Vector2 hitPoint)
    {
        rb2D.velocity = new Vector2(-bounceSpeed.x * hitPoint.x, bounceSpeed.y);
    }

}


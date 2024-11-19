using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb2D;
    private Vector2 Direction;
   
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  //Asign the component of Rigid Body to our variable
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = Vector2.right * Speed;  //the bullet speed is based on the player speed and its direction is given by a vector
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet() //bullet disappears after impact an object
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)              //it seeks for a collider to impact and generate damage
    {
        HorizontalMovement avatar = collision.collider.GetComponent<HorizontalMovement>();
        Wolfscript wolf = collision.collider.GetComponent<Wolfscript>();

        //if (avatar != null)
        //{
        //    avatar.Hit();
        //}
        if (wolf != null)
        {
            wolf.Hit();
        }
        DestroyBullet();
    }




}

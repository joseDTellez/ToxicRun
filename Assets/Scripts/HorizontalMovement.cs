using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [Header("References")]

    private Rigidbody2D rb2D;

    private Animator animator;

    [Header("Movemente")]

    [SerializeField] private float moveVelocity;

    [Header("Jump")]

    [SerializeField] private float jumpForce;

    [SerializeField] private Transform groundController;

    [SerializeField] private Vector2 boxDimensions;

    [SerializeField] private LayerMask whatsGround;

    private bool inGround;

    private bool jump;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        rb2D.velocity = new Vector2(moveVelocity, rb2D.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        inGround = Physics2D.OverlapBox(groundController.position, boxDimensions, 0, whatsGround);
        animator.SetBool("inGround", inGround);

    }

    private void FixedUpdate()
    {
        if (jump && inGround)
        {
            Jump();
        }

        jump = false;
    }

    private void Jump()
    {
        rb2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
        inGround = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundController.position, boxDimensions);
    }


}


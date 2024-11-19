using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Life : MonoBehaviour
{
    [SerializeField] private float health=3; //life of player
    public event EventHandler playerDeath;

    private HorizontalMovement playerMovement;

    [SerializeField] private float timeLostCotrol;

    private Animator animator;

          //invoce an event 
    private void Start()
    {
        playerMovement = GetComponent<HorizontalMovement>();
        animator = GetComponent<Animator>();
    }

    

    public void takeDamage(float damage, Vector2 position)
    {
        health -= damage;
        if (health <= 0)
        {
            playerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
        animator.SetTrigger("Hit");
        StartCoroutine(lostControl());
        playerMovement.bounce(position);
    }

    //public void EventPlayerDeath()      //method to call the event of death
    //{
    //  if (health <= 0)
    //    {
    //        playerDeath?.Invoke(this, EventArgs.Empty);
    //        Destroy(gameObject);
    //    }
        
    //}

    private IEnumerator lostControl()  //frezzes avatar after a collition
    {
        playerMovement.canMove = false;
        yield return new WaitForSeconds (timeLostCotrol);
        playerMovement.canMove = true;
    }
}

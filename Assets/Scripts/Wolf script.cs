using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfscript : MonoBehaviour
{
    private int Health = 1; //standar life of enemy
    private void OnCollisionEnter2D(Collision2D other)              //funtion which compare tags beteewn player and enemies 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Life>().takeDamage(1, other.GetContact(0).normal);
        }
    }
    public void Hit()           //what happens if it's touched
    {
        Health = Health - 1;

        if (Health == 0) Destroy(gameObject); // Dissappears enemy after being attcacked by player
    }
}

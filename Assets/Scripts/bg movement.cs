using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmovement : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    private Vector2 offset;

    private Material material;

    private Rigidbody PlayerRB;


    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        //PlayerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        offset = moveSpeed* Time.deltaTime; 
        //offset = (PlayerRB.velocity.x*0.1f)*moveSpeed*Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float speed;    //velocidad maxima del jugador eje x
    public float direction = 0f;//direccion derecha oizquierda
    public float jumpforce ;     //fureza del salto en eje y
   
    public Rigidbody2D rb;
    public LayerMask layers;
        
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //clase propia de Unity para dar rigidez al objeto
    }

   void Update() 
    {
        Movement();

       
    }
    private void FixedUpdate() //actualizacion constante de estado del teclado en tiempo real
    {
        rb.velocity = new Vector2 (direction * speed, rb.velocity.y);

    }
    private void Movement()  //funcion movimiento
    {
        direction = Input.GetAxisRaw("Horizontal"); //se optiene direccion por ingreso de teclado
        

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1f, Color.blue);//dibujar rayo hacia abajo que choca contra el suelo para detectar que hay piso (posicion,posicion+lineaHaciaAbajo*tamanoPersonaje,rayoAzul)
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f, layers)) //condicional que detecta la colision con la plataforma 
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce); //salta en eje Y con fuerza de la variable jump
            }
        }


    }
   


}

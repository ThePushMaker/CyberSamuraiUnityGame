using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public AudioClip Sound;

    public float Speed;

    private Rigidbody2D Rigidbody2D;
    // Vector 2 contiene la dirección en la que va a avanzar la bala 
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void FixedUpdate()
    {
         Rigidbody2D.velocity = Direction * Speed;
    }

// Recibe una dirección y se la asigna a la variable global
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        // Destuye la bala
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D (Collider2D collision) 
    {
         // si nos devuelve el componente es porque si lo ha colisionado
        JohnMovement john = collision.GetComponent<JohnMovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();
        if (john != null) //Si john existe significa que hemos chocado con john
        { 
            john.Hit(); 
        }
        if (grunt != null)
        {
            grunt.Hit();
        }
        // DestroyBullet();
    }

    // evento especial de unity que se va a llamar cada vez que la bala choque con algo
    // private void OnCollisionEnter2D(Collision2D collision) 
    // {
       
    // }

}

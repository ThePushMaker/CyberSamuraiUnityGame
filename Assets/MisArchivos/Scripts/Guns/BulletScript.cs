using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{


    public AudioClip Sound;

    // Vector 2 contiene la dirección en la que va a avanzar la bala 
    private Vector2 Direction;

    // [Range(1, 100)]
    [SerializeField] private float speed = 1000f;

    // [Range(1, 10)]
    [SerializeField] private float lifeTime = 0.5f;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DestroyBullet(lifeTime);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }


    private void FixedUpdate()
    {
         rb.velocity = transform.up * speed;  
    }

// Recibe una dirección y se la asigna a la variable global
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet(float time)
    {
        Destroy(gameObject, time);
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
         // si nos devuelve el componente es porque si lo ha colisionado
        GruntScript enemy = other.GetComponent<GruntScript>();
        MainCharacterMovement mainCharacter = other.GetComponent<MainCharacterMovement>();
        if (enemy != null)
        {
            enemy.Hit();
            Debug.Log("hit enemy");
        }
        if (mainCharacter != null) //Si  existe significa que hemos chocado con ello
        { 
            mainCharacter.Hit(); 
            Debug.Log("hit mainCharacter");
        }
        DestroyBullet(0);
    }

    // evento especial de unity que se va a llamar cada vez que la bala choque con algo
    // private void OnCollisionEnter2D(Collision2D collision) 
    // {
       
    // }

}

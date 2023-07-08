using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{

    // Las varaibles publicas se pueden editar directamente en el inspector de unity
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;

    // Se crean las variable para contener los componentes importados
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded; //si el objeto esta en el suelo
    // almacena el tiempo en el que se hizo el ultimo disparo
    private float LastShoot;
    private int Health = 5;


    // Start is called before the first frame update
    void Start()
    {
        // toma el componente rigidbody del personaje y lo mete dentro del script (este)
        Rigidbody2D = GetComponent<Rigidbody2D>();
        // importamos el componente animator
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // recibe el eje horizontal de las teclas del teclado
        Horizontal = Input.GetAxisRaw("Horizontal");

        // Girar el perosnaje a la direccion que camina, si se va a la izquierda se voltea
        // El componente transform no necesita importarse
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // si horizontal es = 0 va a valer falso
        Animator.SetBool("Running", Horizontal != 0.0f);

        // Esto es lo mismo que abajo pero mostrando el rayo 
        // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        // Esto lanza un rayo hacia abajo del personaje que detecta si hay suelo o no
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = true; //cabiar esto a false para desactivar saltos infinitos

        // Cada vez que el jugador presiona la w y esté sobre el suelo se va a ejecutar esta función Jump() que yo mismo cree
        if(Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        // No podremos disparar hasta que la variable de tiempo sea mayor a 0.25
        if(Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    

        // Cuando se trabaja con fisicas se debe de utilizar la función fixedUpdate(), no el Update() normal. Esto es porque las fisicas necesitan actualizarse de manera muy frecuente
    private void FixedUpdate()
    {
        // Esta función recibe los valores X y Y del mundo, solo modificamos la variable Horizontal (X) y dejamos la Y como estaba
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    // esta función hace es tomar el rigidbody y le agrega una fuerza hacia arriba. El verctor2.up se multiplica por el JumpForce porque dejar el vector2.up solo, le agrega demasiada poca fuerza y ni siquiera se nota que el personaje salte
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction= Vector3.left;

        // Esta funcion instantiate, lo que hace es toma un prefab, en este caso la bala y lo duplica en algun sitio del mundo
        // valores: QueObjeto, QueUbicacion, QueRotacion
        // Transform.position quiere decir que en nuestra ubicacion 
        GameObject bullet = Instantiate(BulletPrefab, (transform.position) + direction * 0.1f, Quaternion.identity);
        // con esto obtenemos el componenteBulletScript
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }



    public void Hit() 
    {
        Health -= 1;
        if(Health == 0) Destroy(gameObject, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    // Las varaibles publicas se pueden editar directamente en el inspector de unity
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded; //si el objeto esta en el suelo

    // Start is called before the first frame update
    void Start()
    {
        // toma el componente rigidbody del personaje y lo mete dentro del script JohnMovement (este)
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // recibe el eje horizontal de las teclas del teclado
        Horizontal = Input.GetAxisRaw("Horizontal");

        // Esto es lo mismo que abajo pero mostrando el rayo 
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        // Esto lanza un rayo hacia abajo del personaje que detecta si hay suelo o no
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Cada vez que el jugador presiona la w y esté sobre el suelo se va a ejecutar esta función Jump() que yo mismo cree
        if(Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    // esta función hace es tomar el rigidbody y le agrega una fuerza hacia arriba. El verctor2.up se multiplica por el JumpForce porque dejar el vector2.up solo, le agrega demasiada poca fuerza y ni siquiera se nota que el personaje salte
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    // Cuando se trabaja con fisicas se debe de utilizar la función fixedUpdate(), no el Update() normal. Esto es porque las fisicas necesitan actualizarse de manera muy frecuente
    private void FixedUpdate()
    {
        // Esta función recibe los valores X y Y del mundo, solo modificamos la variable Horizontal (X) y dejamos la Y como estaba
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
}

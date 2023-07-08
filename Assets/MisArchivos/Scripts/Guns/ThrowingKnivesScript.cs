using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnivesScript : MonoBehaviour
{
    public GameObject John;

    // Gun variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;


    private Rigidbody2D rb;


    private float fireTimer;

    private Vector2 mousePos;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (John != null) 
        {
            // Se toma la posicion de la camara
            Vector3 position = transform.position;
            // Solo en el eje X, que es de de izquierda a derecha, vamos a compiarnos la posición de john
            position.x = John.transform.position.x;
            position.y = John.transform.position.y+3f;
            transform.position = position;

        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // left mouse button = 0
        // GetMouseButtonDown es para que se active cada vez que se haga click
        // GetMouseButton es para que se active con solo mantener el mouse presionado (sin hacer multiples clicks)
        if(Input.GetMouseButton(0) && fireTimer <= 0f){
            Shoot();
            fireTimer = fireRate;
        } else {
            fireTimer -= Time.deltaTime;
        }
    }

    private void Shoot(){
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}

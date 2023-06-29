using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Se crea variable que haga referencia a john
    public GameObject John;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (John != null) 
        {
            // Se toma la posicion de la camara
            Vector3 position = transform.position;
            // Solo en el eje X, que es de de izquierda a derecha, vamos a compiarnos la posición de john
            position.x = John.transform.position.x;
            // position.y = John.transform.position.y+1;
            transform.position = position;

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPos;
    private GameObject cam;
    
    // La diferencia entre SerializeField y public es que serialize fiel muestra la variable en el editor, pero no permite que otros scripts accedan a este especifico campo. Pero quiero ser capaz de ir a mi editor y cambiar manualmente lo que yo quiero que estos numeros sean, asi podemos guardar estos datos dentro de la memoria del editor
    [SerializeField] private float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos +  distance, transform.position.y, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundScript : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start() {
        cameraTransform = Camera.main.transform; 
        lastCameraPosition = cameraTransform.position;        
    }

    private void Update() { 
         Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
         transform.position += deltaMovement;
         lastCameraPosition = cameraTransform.position;
    }
}

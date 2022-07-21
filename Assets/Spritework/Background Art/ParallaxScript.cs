using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float _lagAmount = 0f;
    
    Vector3 previousCameraPosition;
    Transform camera;
    Vector3 targetPosition;

    private float ParallaxAmount => 1f - _lagAmount;

    private void Awake()
    {
        camera = Camera.main.transform;
        previousCameraPosition = camera.position; 

        
    }

    private void LateUpdate()
    {
        Vector3 movement = CameraMovement;
        if (movement == Vector3.zero) return;
        targetPosition = new Vector3(transform.position.x + movement.x * ParallaxAmount, transform.position.y, transform.position.z);
        transform.position = targetPosition; 
    }


    Vector3 CameraMovement 
    {
        get

        {
            Vector3 movement = camera.position - previousCameraPosition;
            previousCameraPosition = camera.position;
            return movement; 

        }
    
    
    
    
    }
}

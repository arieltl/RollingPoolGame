using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    public GameObject player;
    public float rotationRate = 2f;
    public SpeedOffset speedOffset;
    public Vector2 maxInputOffset = new Vector2(60,30);
    
    public Vector3 testVector = Vector3.up;
    Vector2 inputOffset = Vector2.zero;
    Quaternion camOffset;
    InputController controls;

    PlayerController playerController;
    Rigidbody rb;
    Vector3 baseOffset;
    
    
    void Awake()
    { 
        camOffset = Quaternion.identity;
        controls =  new InputController();
        controls.Gameplay.Camera.performed += ctx => inputOffset = ctx.ReadValue<Vector2>();
        controls.Gameplay.Camera.canceled += ctx => inputOffset = Vector2.zero;
    }


    void Start()
    {
        baseOffset = transform.position - player.transform.position;
        rb = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
    }

    void LateUpdate()
    {
        
        // Calculate movement direction
        var velocity = rb.velocity;
        if (velocity.magnitude > 0.1f) {
            var angle = 90 - Mathf.Atan2(velocity.z, velocity.x) * Mathf.Rad2Deg;
            
            // Calculate input offset
            var xInput = Mathf.LerpUnclamped(0, maxInputOffset.x, inputOffset.x);
            var yInput = Mathf.LerpUnclamped(0, maxInputOffset.y, inputOffset.y);
            var xAngle = 13f;


            // Apply camera Rotationdws
            Quaternion targetRotation = Quaternion.Euler(xAngle - yInput, angle + xInput, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationRate);

            // Calculate and Apply Camera Position Offset
            var speed = Mathf.Clamp(velocity.magnitude, 0, 25);
            var offsetFactor = Mathf.Lerp(speedOffset.min, speedOffset.max, speed / 25);
            var x = Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad) * baseOffset.z * offsetFactor;
            var z = Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad) * baseOffset.z * offsetFactor;
            transform.position = player.transform.position + new Vector3(x, baseOffset.y, z);
        }
    }
    
    
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}




[System.Serializable]
public struct SpeedOffset
{
    public float min;
    public float max;
}


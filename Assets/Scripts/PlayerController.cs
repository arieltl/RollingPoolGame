using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{

    
    public float speed = 10f;
    
    
    bool braking = false;
    InputController controls;
    Vector2 movement = new Vector2();
    Rigidbody rb;
    float lastAngle = 0f;
    bool moving = false;
    void Awake()
    {
        Debug.Log(speed);
        rb = gameObject.GetComponent<Rigidbody>();
        controls = new InputController();
        controls.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => movement = Vector2.zero;

    }


    void FixedUpdate()
    {
        var velocity = rb.velocity;
        var angle = 90 - Mathf.Atan2(velocity.z, velocity.x) * Mathf.Rad2Deg;
        braking = movement.y < 0;
        float yInput = movement.y;
        if (braking)
        {
            if (velocity.magnitude > 0.1)
            {
                yInput = -0.5f;
            }
            else
            {
                yInput = 0;
            }
        }
        if (!moving)
        {
            angle = lastAngle;
        }
        var move = Quaternion.AngleAxis(angle, Vector3.up) * (new Vector3(movement.x, 0, yInput ) * speed);


        rb.AddForce(move);
        rb.angularDrag = (velocity.magnitude > 0.15f) ? 0.05f : 15;
        moving = (velocity.magnitude > 0.15f);
        lastAngle = angle;

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

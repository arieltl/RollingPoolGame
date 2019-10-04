using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{

    
    public float speed = 3;
    public float impulseSpeed = 10;

    bool applyImpulse;
    bool braking;
    InputController controls;
    Vector2 movement;
    Rigidbody rb;
    float lastAngle;
    bool moving;
    void Awake()
    {
        Debug.Log(speed);
        rb = gameObject.GetComponent<Rigidbody>();
        controls = new InputController();
        controls.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => movement = Vector2.zero;
        controls.Gameplay.Impulse.performed += ctx => applyImpulse = true;

    }


    void FixedUpdate()
    {
       
        var velocity = rb.velocity;
        if (!applyImpulse)
        {
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

            var move = Quaternion.AngleAxis(angle, Vector3.up) * (new Vector3(movement.x, 0, yInput) * speed);


            rb.AddForce(move);


            rb.angularDrag = (velocity.magnitude > 0.15f) ? 0.05f : 15;
            moving = (velocity.magnitude > 0.15f);
            lastAngle = angle;
        }
        else
        {
            var move = velocity.normalized * impulseSpeed;
            rb.AddForce(move, ForceMode.Impulse);
            applyImpulse = false;
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{

    public float speed = 10f;
    
    Vector2 movement;
    InputController inputController;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputController = new InputController();
        inputController.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        inputController.Gameplay.Movement.canceled += ctx => movement = Vector2.zero;
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(movement.x,0, movement.y) * speed);
    }

    void OnEnable()
    {
        inputController.Gameplay.Enable();
    }

    void OnDisable()
    {
        inputController.Gameplay.Disable();
    }
}

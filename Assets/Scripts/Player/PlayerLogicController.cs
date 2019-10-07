using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
    }
}

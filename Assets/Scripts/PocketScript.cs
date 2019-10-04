using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PocketScript : MonoBehaviour
{

    GameManager manager;

    void Start()
    {
        manager = GetComponentInParent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            manager.Score++;
        }
    }
    
}

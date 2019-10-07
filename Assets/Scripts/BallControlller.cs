using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlller : MonoBehaviour
{
   
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        manager.AddBall(this);
    }
    
}

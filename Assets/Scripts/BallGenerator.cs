using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ball;
    void Start()
    {
       
    }

    public void GenerateBall(Vector2 Positon)
    {
        var ballInst = Instantiate(ball, new Vector3(Positon.x, 0.5f, Positon.y), Quaternion.identity);
        ballInst.transform.parent = transform;
    }
    
}

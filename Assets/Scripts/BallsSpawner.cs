using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{
    public GameObject ball;
    float radius = 0.5f;
    void Start()
    {
        GenerateTriangle(1,1,Vector2.zero);
    }

    void GenerateTriangle(int layer, int count,Vector2 position)
    {
        if (layer < 6)
        {
            Debug.Log(new Vector2(layer, count));
            GenerateBall(position);

            if (count == layer)
            {
                var firstBallOnLayerX = position.x - (2 * radius * (layer - 1));
                var nextPosition = new Vector2(firstBallOnLayerX - radius,
                    position.y + Mathf.Sin(60 * Mathf.Deg2Rad * radius * 2 ));
                GenerateTriangle(layer + 1, 1, nextPosition);
            }
            else
            {
                var nextPosition = new Vector2(position.x + 2 * radius, position.y);
                GenerateTriangle(layer, count + 1, nextPosition);
            }
        }
    }
    
    void GenerateBall(Vector2 Positon)
    {
        var ballInst = Instantiate(ball, new Vector3(Positon.x, 0.5f, Positon.y), Quaternion.identity);
        ballInst.transform.parent = transform;
    }
}


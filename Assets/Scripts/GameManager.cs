using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<BallControlller> gameBalls = new List<BallControlller>();
    
    int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            Debug.Log(score);
        }
    }

    public void AddBall(BallControlller ball)
    {
        gameBalls.Add(ball);
        Debug.Log(gameBalls.Count);
    }
}

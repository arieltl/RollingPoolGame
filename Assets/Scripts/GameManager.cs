using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> gameBalls = new List<GameObject>();

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
}

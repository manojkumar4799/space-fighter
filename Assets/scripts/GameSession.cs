using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int Score = 0;

    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int CountGameSession = FindObjectsOfType<HeroShip>().Length;
        if(CountGameSession>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return Score;
    }

    public void AddScore(int TotalScore)
    {
        Score += TotalScore;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}

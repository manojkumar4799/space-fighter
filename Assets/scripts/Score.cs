using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text ScoreText;
    GameSession gamesession;
    void Start()
    {
        ScoreText = GetComponent<Text>();
        gamesession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = gamesession.GetScore().ToString();
    }
}

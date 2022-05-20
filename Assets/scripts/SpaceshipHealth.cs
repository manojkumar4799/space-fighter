using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipHealth : MonoBehaviour
{
    Text ScoreText;
    HeroShip PlayerHealth;
    void Start()
    {
        ScoreText = GetComponent<Text>();
        PlayerHealth = FindObjectOfType<HeroShip>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = PlayerHealth.PlayerLife().ToString();
        
    }
}

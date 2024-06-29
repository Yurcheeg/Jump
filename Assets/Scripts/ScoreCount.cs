using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreCount : MonoBehaviour
{
    private int score;
    private int highscore;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;
    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = $"Highscore : {highscore}";
    }
    private void Update()
    {
        score = (int)Camera.main.transform.position.y;
        scoreText.text = $"Score: {score}";
        if(Player.currentState == Player.PlayerState.Dying)
        {
            if (score > highscore)
            {
                highscore = score;
                highscoreText.text = $"Highscore : {highscore}";
                PlayerPrefs.SetInt("Highscore",highscore);
            }
        }
        
    }
}

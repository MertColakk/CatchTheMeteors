using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Variables
    [SerializeField] TMP_Text text,highScoreText;
    public Image gameOverImage;
    int gameScore,highScore;


    // PlayerPrefs keys
    const string HighScoreKey = "HighScore";

    void Start()
    {
        gameScore = 0;
        
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateHighScoreText();

        gameOverImage.gameObject.SetActive(false);
    }

    public void addToScore(int amount)
    {
        gameScore += amount;
        text.text = "Score: " + gameScore.ToString();

        if (gameScore > highScore)
        {
            highScore = gameScore;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}

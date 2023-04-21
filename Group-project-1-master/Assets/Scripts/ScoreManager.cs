using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public GameOverScreen GameOverScreen;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Highscore and score on screen

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "POINTS: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

    }

    //Highscore
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "POINTS: " + score.ToString();
        if (highscore < score)
        PlayerPrefs.SetInt("highscore", score);

    }

}

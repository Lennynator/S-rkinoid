using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class scoremanager : MonoBehaviour
{
    public static scoremanager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int score = 0;
    public int highscore = 0;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        print(score);
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = PlayerPrefs.GetInt("score");
        scoreText.text = score.ToString() + "POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();


    }

    public void addpoint()
    {
        score += 1;
        scoreText.text = score.ToString() + "POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        print(score);


    }
}

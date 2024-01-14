using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Showscore : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int score;
    int highscore;

    void Start()
    {
        score = PlayerPrefs.GetInt("score");
      


        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHighscore : MonoBehaviour
{
    public int classicHighScore = 0;
    public int arcadeHighScore = 0;
    public int zenHighScore = 0;

    [SerializeField] TextMesh classicHighScoreText;
    [SerializeField] TextMesh arcadeHighScoreText;
    [SerializeField] TextMesh zenHighScoreText;

    void Start()
    {
        classicHighScore = PlayerPrefs.GetInt("ClassicHigh", 0);
        classicHighScoreText.text = classicHighScore.ToString();

        arcadeHighScore = PlayerPrefs.GetInt("ArcadeHigh", 0);
        arcadeHighScoreText.text = arcadeHighScore.ToString();

        zenHighScore = PlayerPrefs.GetInt("ZenHigh", 0);
        zenHighScoreText.text = zenHighScore.ToString();
    }

}

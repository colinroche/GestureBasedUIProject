using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    [Header("Player's Score")]
    [SerializeField] TextMesh scoreText;
    [SerializeField] TextMesh highScoreText;
    [SerializeField] TextMesh countdownText;


    [SerializeField] GameObject strikeLeft;
    [SerializeField] GameObject strikeMiddle;
    [SerializeField] GameObject strikeRight;
    [SerializeField] GameObject mainMenuGems;
    [SerializeField] GameObject spawnGems;

    int playerScore = 0;
    int highscore = 0;
    int bombCount = 0;
    int endGame = 3;
    int currentLevel;
    float currentTime;
    float startingtime = 60f;   // Amount of time player has to complete level
    bool gameOver = false;
    private bool addTen = false;
    /*private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        /*else {
            DontDestroyOnLoad(gameObject);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        LevelCheck();
        if(currentLevel == 1)
        {
            highscore = PlayerPrefs.GetInt("ClassicHigh", 0);
        }
        else if(currentLevel == 2)
        {
            highscore = PlayerPrefs.GetInt("ArcadeHigh", 0);
        }
        else if(currentLevel == 3)
        {
            highscore = PlayerPrefs.GetInt("ZenHigh", 0);
        }
        //Instance = this;
        currentTime = startingtime;
        scoreText.text = playerScore.ToString();
        highScoreText.text = highscore.ToString();
    }

    public void AddScore(int scoreValue)
    {
        playerScore += scoreValue;
        scoreText.text = playerScore.ToString();
    }

    public void BombCheck() {
        bombCount++;
        if (bombCount == 1)
        {
            strikeLeft.SetActive(true);
        }
        else if (bombCount == 2)
        {
            strikeMiddle.SetActive(true);
        }
        else if (bombCount == endGame)
        {
            strikeRight.SetActive(true);
        }

        if (bombCount >= endGame)
        {
            EndGame();
            bombCount = 0;
        }
    }
    public void LevelCheck()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            currentLevel = 1;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            currentLevel = 2;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            currentLevel = 3;
        }
    }
    public void EndGame()
    {
        LevelCheck();
        if(currentLevel == 1)
        {
            if(playerScore >  PlayerPrefs.GetInt("ClassicHigh", 0))
            {
                print("classic");
                highscore = playerScore;
                highScoreText.text = highscore.ToString();
                PlayerPrefs.SetInt("ClassicHigh", highscore);
            }
        }
        else if(currentLevel == 2)
        {
            print("2");
            if(playerScore >  PlayerPrefs.GetInt("ArcadeHigh", 0))
            {
                print("arcade");
                highscore = playerScore;
                highScoreText.text = highscore.ToString();
                PlayerPrefs.SetInt("ArcadeHigh", highscore);
            }
        }
        else if(currentLevel == 3)
        {
            if(playerScore >  PlayerPrefs.GetInt("ZenHigh", 0))
            {
                highscore = playerScore;
                highScoreText.text = highscore.ToString();
                PlayerPrefs.SetInt("ZenHigh", highscore);
            }
        }
       
        SceneManager.LoadScene(currentLevel);
        //mainMenuGems.SetActive(true);
        //spawnGems.SetActive(false);
    }

     public void Countdown()
    {
        LevelCheck();
        if(currentLevel == 2 || currentLevel == 3)
        {
            print(gameOver);
            if(gameOver == false){
                countdownText.text = currentTime.ToString();
                currentTime -= 1 * Time.deltaTime;  // Remove a second every second
            
                if(currentTime <= 10)
                {   // Warning
                    countdownText.color = Color.red;
                }

                if(currentTime <=0)
                {  
                    GameSession gameSession = new GameSession();
                    gameSession.EndGame();
                }
            }
        }
    }

    public void StartTimer()
    {
        gameOver = false;
        currentTime = startingtime;
        print("Start timer ");
    }

    public void AddTenSecs()
    {   // Called from Item Drop
        currentTime += 10;
        addTen = true;
    }

    void Update()
    {
        Countdown();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ArcadeGameSession : MonoBehaviour
{
    [Header("Player's Score")]
    [SerializeField] TextMesh scoreText;

    [SerializeField] GameObject mainMenuGems;
    [SerializeField] GameObject spawnGems;
    public static ArcadeGameSession Instance;

    float currentTime;
    float startingtime = 60f;   // Amount of time player has to complete level
    private bool gameOver = false;
    private bool addTen = false;


    [SerializeField] TextMesh countdownText;


    int playerScore = 0;
    int bombCount = 0;
    int endGame = 3;
    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        currentTime = startingtime;
        scoreText.text = playerScore.ToString();
    }

    public void AddScore(int scoreValue)
    {
        playerScore += scoreValue;
        scoreText.text = playerScore.ToString();
    }


    public void EndGame()
    {
        mainMenuGems.SetActive(true);
        spawnGems.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;  // Remove a second every second
        countdownText.text =  currentTime.ToString();

        if (currentTime <= 10)
        {   // Warning
            countdownText.color = Color.red;
        }

        if(currentTime <=0)
        {
            Instance.gameOver = true;
        }
        
    }
}

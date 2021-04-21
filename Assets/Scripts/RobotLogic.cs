using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class RobotLogic : MonoBehaviour
{
    public List<int> colorList;
    public float showtime = 0.5f;   // Highlight Color
    public float pausetime = 0.5f;  // Normal Color
    
    // Game objects
    public int level = 2;   // Two color sequence at start
    private int playerLevel = 0;
    // Who's turn is it
    private bool robot = false; 
    public bool player = false;

    // Color changes each turn
    private int randomColor;
    // Menu
    public Button StartButton;
    public Text gameOverText;
    public Text scoreText;
    public Text highScore;
    public int score;

    public GameObject startButton;
    public GameObject pauseButton;

    public GameObject startGem;
    public GameObject pauseGem;
    public Rigidbody mainMenuGemRb;
    private bool spaceBool = true;
    private bool pauseMenuBool = true;
    private int gemRotateVal = 0;

    public float speed;
    public float angularSpeed;
    public void Start()
    {
        mainMenuGemRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        speed = mainMenuGemRb.velocity.magnitude;
        angularSpeed = mainMenuGemRb.angularVelocity.magnitude / Mathf.PI * 2;
        mainMenuGemRb.angularVelocity = new Vector3(0, Mathf.PI * gemRotateVal, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        print("Collision");
        if(col.tag == "Sword")
        {
            gemRotateVal = gemRotateVal + 20;
            //SceneManager.LoadScene(0);
        }
        
    }
 

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            startButton.SetActive(!spaceBool);
            pauseButton.SetActive(!spaceBool);
            spaceBool = !spaceBool;
        }     
    }



    public void StartGame()
    {
        robot = true;
        score = 0;
        playerLevel = 0;
        level = 2;  // Two color sequence at start
        gameOverText.text = "";
        scoreText.text = score.ToString();
        StartButton.interactable = false;
    }

    private void GameOver()
    {
        gameOverText.text = "Game Over";
        StartButton.interactable = true;
        player = false;
    }


}

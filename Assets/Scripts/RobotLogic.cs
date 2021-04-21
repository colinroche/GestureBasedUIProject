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
    [SerializeField]  Button StartButton;
    [SerializeField]  Text gameOverText;
    [SerializeField]  Text scoreText;
    [SerializeField]  Text highScore;
    [SerializeField]  int score;


    [SerializeField]  GameObject startGem;
    [SerializeField]  GameObject pauseGem;
    [SerializeField]  Rigidbody mainMenuGemRb;
    private bool pauseMenuBool = true;
    private int gemRotateVal = 0;
    [SerializeField] ParticleSystem gemExplosion;

    public float speed;
    public float angularSpeed;
    private float triggerCount = 0;
    [SerializeField] AudioClip gemHitSFX;
    [SerializeField] AudioClip gemBreakSFX;

    [SerializeField] AudioSource audioSrc;


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
            triggerCount++;
            audioSrc.PlayOneShot(gemHitSFX);
            if(triggerCount == 3)
            {
                gemExplosion = GetComponent<ParticleSystem>();
                audioSrc.PlayOneShot(gemBreakSFX);
                gemExplosion.Play();
            }
            gemRotateVal = gemRotateVal + 20;


            //SceneManager.LoadScene(0);
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

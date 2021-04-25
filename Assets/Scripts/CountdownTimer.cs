﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    //public static CountdownTimer Instance;
    [SerializeField] GameObject mainMenuGems;
    [SerializeField] GameObject spawnGems;


    float currentTime;
    float startingtime = 60f;   // Amount of time player has to complete level
    bool gameOver = false;
    private bool addTen = false;

    [SerializeField] TextMesh countdownText;

    void Start()
    {
        //Instance = this;
        currentTime = startingtime;
    }

    public void StartTimer()
    {
        gameOver = false;
        currentTime = startingtime;
        print("Start timer ");
    }

    void Update()
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
                // Set TimeBoard to 0
                currentTime = 0;
                countdownText.text = currentTime.ToString();
                gameOver = true;
                // Reset TimeBoard
                // currentTime = startingtime;
                spawnGems.SetActive(false);
                mainMenuGems.SetActive(true);
                gameObject.SetActive(false);
                SceneManager.LoadScene(2);
            }
        }
    }

    public void AddTenSecs()
    {   // Called from Item Drop
        print("dlajfldjfaljdlfjakdjflajdflkjsdalfjasldjf");
        currentTime += 10;
        addTen = true;
    }
}
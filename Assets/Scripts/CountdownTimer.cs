﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    //public static CountdownTimer Instance;
    [SerializeField] GameObject mainMenuGems;
    [SerializeField] GameObject spawnGems;


    float currentTime;
    float startingtime = 5f;   // Amount of time player has to complete level
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
        this.currentTime = startingtime;
        print("Start timer ");
    }

    void Update()
    {
        print(gameOver);
        if(gameOver == false){
            currentTime -= 1 * Time.deltaTime;  // Remove a second every second
            countdownText.text =  currentTime.ToString();
        
            if(currentTime <= 10)
            {   // Warning
                countdownText.color = Color.red;
            }

            if(currentTime <=0)
            {
                currentTime = 0;
                //Instance.gameOver = true;
                gameOver = true;
                spawnGems.SetActive(false);
                mainMenuGems.SetActive(true);
            }
        }
    }

    public void AddTenSecs()
    {   // Called from Item Drop
        currentTime += 10;
        addTen = true;
    }
}
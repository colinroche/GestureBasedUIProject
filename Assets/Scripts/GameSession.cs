﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    [Header("Player's Score")]
    [SerializeField] TextMesh scoreText;

    [SerializeField] GameObject strikeLeft;
    [SerializeField] GameObject strikeMiddle;
    [SerializeField] GameObject strikeRight;
    [SerializeField] GameObject mainMenuGems;
    [SerializeField] GameObject spawnGems;


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
        scoreText.text = playerScore.ToString();
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
        }
    }

    public void EndGame()
    {
        mainMenuGems.SetActive(true);
        spawnGems.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

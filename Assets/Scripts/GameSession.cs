using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    [Header("Player's Score")]
    [SerializeField] TextMesh scoreText;

    int playerScore = 0;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    [SerializeField]  GameObject UIToggle;
    private bool spaceBool = true;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            UIToggle.SetActive(!spaceBool);
            spaceBool = !spaceBool;
        }     
    }
    public void PauseGame()   // To be called from Menu Resume button
    {
        pauseMenu.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0;
    }
    public void UnpauseGame()   // To be called from Menu Resume button
    {
        pauseMenu.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void GameMenu ()
    {
        SceneManager.LoadScene(0);
    }
    public void Classic ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
    }

    public void Arcade ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 2);
    }

    public void Zen ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 3);
    }

    public void QuitGame()
    {
        Application.Quit();  
    }
}

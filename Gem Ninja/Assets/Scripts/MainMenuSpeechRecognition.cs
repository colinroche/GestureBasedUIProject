using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;  // for stringbuilder
using UnityEngine;
using UnityEngine.Windows.Speech;   // grammar recogniser
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuSpeechRecognition : MonoBehaviour
{
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private GrammarRecognizer gr;
    [SerializeField]  GameObject UIToggle;
    private bool spaceBool = false;
    [SerializeField] GameObject DifficultyMenu;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject LeaderboardMenu;
    [SerializeField] VolumeSlider volumeSlider = new VolumeSlider();
    SoundManager soundManager = new SoundManager();
    

    private void Start()
    {   // Main menu buttons
        actions.Add("gameUI", GameUI);
        actions.Add("play", Play);
        actions.Add("volume", Leaderboard);
        actions.Add("quit", Quit);
        actions.Add("back", Back);

        actions.Add("arcade", Arcade);
        actions.Add("classic", Classic);
        actions.Add("zen", Zen);

        actions.Add("off", Off);
        actions.Add("twentyFive", TwentyFive);
        actions.Add("fifty", Fifty);
        actions.Add("seventyFive", SeventyFive);
        actions.Add("oneHundred", OneHundred);


        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, 
                                                "GameGrammar.xml"), 
                                    ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!");
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning) Debug.Log("Recogniser running");
    }

    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder message = new StringBuilder();
        Debug.Log("Recognised a phrase");
        Debug.Log("You said " + message);
        // read the semantic meanings from the args passed in.
        SemanticMeaning[] meanings = args.semanticMeanings;

        // use foreach to get all the meanings.
        foreach(SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();
           // message.Append("Key: " + keyString + ", Value: " + valueString + " ");
            message.Append("You said " + valueString);
            actions[valueString].Invoke();
        }
        // use a string builder to create the string and out put to the user
        Debug.Log(message);
    }
    private void GameUI()
    {
        UIToggle.SetActive(!spaceBool);
        spaceBool = !spaceBool;
    }
    private void Play()
    {
        MainMenu.SetActive(false);
        DifficultyMenu.SetActive(true);
    }
    private void Leaderboard()
    {
        MainMenu.SetActive(false);
        LeaderboardMenu.SetActive(true);
    }
    private void Back()
    {
        MainMenu.SetActive(true);
        DifficultyMenu.SetActive(false);
        LeaderboardMenu.SetActive(false);
    }
    private void Quit()
    {
        Debug.Log("Quiting...");
        Application.Quit();  
    }

    private void Arcade()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
    }
  
    private void Classic()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 2);
    }

    private void Zen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 3);
    }

    private void Off()
    {
        volumeSlider.SetVolume(0f);
    }

    private void TwentyFive()
    {
        volumeSlider.SetVolume(25f);
    }
    private void Fifty()
    {
        volumeSlider.SetVolume(50f);
    }
    private void SeventyFive()
    {
        volumeSlider.SetVolume(75f);
    }
    private void OneHundred()
    {
        volumeSlider.SetVolume(100f);
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }
}

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;  // for stringbuilder
using UnityEngine;
using UnityEngine.Windows.Speech;   // grammar recogniser
using UnityEngine.SceneManagement;


/*
 *  Uses English US in the settings - Keyboard (on the taskbar), Region, Preferred Language and Speech in Settings
 */

public class GameSpeechRecognition : MonoBehaviour
{
    [SerializeField] GameObject Yellow;
    [SerializeField] GameObject Green;
    [SerializeField] GameObject Blue;
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Orange;
    [SerializeField] GameObject Purple;

    [SerializeField] Material MatYellow;
    [SerializeField] Material MatGreen;
    [SerializeField] Material MatBlue;
    [SerializeField] Material MatRed;
    [SerializeField] Material MatOrange;
    [SerializeField] Material MatPurple;

    [SerializeField] Material MatYellowLight;
    [SerializeField] Material MatGreenLight;
    [SerializeField] Material MatBlueLight;
    [SerializeField] Material MatRedLight;
    [SerializeField] Material MatOrangeLight;
    [SerializeField] Material MatPurpleLight;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private GrammarRecognizer gr;

    protected string color = "";

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GamePanel;

    public Vector3 savedPosition; // Position of first color to change with rotation for the last object

    private void Start()
    {   // Color objects
        
        // Game buttons
        actions.Add("start", StartGame);
        actions.Add("pause", Pause);

        // Pause menu buttons
        actions.Add("resume", Resume);
        actions.Add("menu", Menu);
        actions.Add("quit", Quit);
        
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
        // read the semantic meanings from the args passed in.
        SemanticMeaning[] meanings = args.semanticMeanings;

        // use foreach to get all the meanings.
        foreach(SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();
            //message.Append("Key: " + keyString + ", Value: " + valueString + " ");
            message.Append("You said " + valueString);
            actions[valueString].Invoke();
        }
        // use a string builder to create the string and out put to the user
        Debug.Log(message);
    }

    // USER INTERFACE AND PAUSE MENU // 
    private void StartGame()
    {
    }
    private void Pause()
    {
        PauseMenu.SetActive(true);
    }
    private void Resume()
    {
        PauseMenu.SetActive(false);
    }

    private void Menu()
    {
        SceneManager.LoadScene(0);
    }
    private void Quit()
    {
        Debug.Log("Quiting...");
        Application.Quit();  
    }

    // COLORS SPEECH RECOGNITION // 
   

   
    private IEnumerator Click()
    {
        yield return new WaitForSeconds(1f);
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

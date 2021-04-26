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
    
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private GrammarRecognizer gr;

    protected string color = "";
    [SerializeField] GameObject PauseMenu;
        [SerializeField] GameObject AxeReal;
    [SerializeField] GameObject AxeFake;
    [SerializeField] GameObject ClubReal;
    [SerializeField] GameObject ClubFake;
    [SerializeField] GameObject DaggerReal;
    [SerializeField] GameObject DaggerFake;
    [SerializeField] GameObject HammerReal;
    [SerializeField] GameObject HammerFake;
    [SerializeField] GameObject ScytheReal;
    [SerializeField] GameObject ScytheFake;
    [SerializeField] GameObject SpearReal;
    [SerializeField] GameObject SpearFake;
    [SerializeField] GameObject SwordReal;
    [SerializeField] GameObject SwordFake;
    [SerializeField] GameObject GamePanel;
    public int savedVal = 0;

    public Vector3 savedPosition; // Position of first color to change with rotation for the last object


    private void Start()
    {   // Color objects
        
        // Game buttons
        actions.Add("start", StartGame);
        actions.Add("pause", Pause);

        actions.Add("hammer", Hammer);
        actions.Add("axe", Axe);
        actions.Add("club", Club);
        actions.Add("dagger", Dagger);
        actions.Add("scythe", Scythe);
        actions.Add("spear", Spear);
        actions.Add("sword", Sword);

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
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    private void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    private void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void Quit()
    {
        Debug.Log("Quiting...");
        Application.Quit();  
    }

    // WEAPONS SPEECH RECOGNITION // 
   
    public void Axe()
    {
        resetCurrentWeapon();
        savedVal = 0;
        AxeReal.SetActive(true);
        AxeFake.SetActive(false);
    }
    public void Club()
    {
        resetCurrentWeapon();
        savedVal = 1;
        ClubReal.SetActive(true);
        ClubFake.SetActive(false);
    }
    public void Dagger()
    {
        resetCurrentWeapon();
        savedVal = 2;
        DaggerReal.SetActive(true);
        DaggerFake.SetActive(false);
    }
    public void Hammer()
    {
        resetCurrentWeapon();
        savedVal = 3;
        HammerReal.SetActive(true);
        HammerFake.SetActive(false);
    }


    public void Scythe()
    {
        resetCurrentWeapon();
        savedVal = 4;
        ScytheReal.SetActive(true);
        ScytheFake.SetActive(false);
    }
    public void Spear()
    {
        resetCurrentWeapon();
        savedVal = 5;
        SpearReal.SetActive(true);
        SpearFake.SetActive(false);
    }
    public void Sword()
    {
        resetCurrentWeapon();
        savedVal = 6;
        SwordReal.SetActive(true);
        SwordFake.SetActive(false);
    }

    public void resetCurrentWeapon()
    {
        if(savedVal == 0){
            AxeReal.SetActive(false);
            AxeFake.SetActive(true);
        }else if(savedVal == 1){
            print("Club");
            ClubReal.SetActive(false);
            ClubFake.SetActive(true);
        }else if(savedVal == 2){
            print("Dagger");
            DaggerReal.SetActive(false);
            DaggerFake.SetActive(true);
        }else if(savedVal == 3){
            print("Hammer");
            HammerReal.SetActive(false);
            HammerFake.SetActive(true);
        }else if(savedVal == 4){
            print("Scythe");
            ScytheReal.SetActive(false);
            ScytheFake.SetActive(true);
        }else if(savedVal == 5){
            print("Spear");
            SpearReal.SetActive(false);
            SpearFake.SetActive(true);
        }else if(savedVal == 6){
            print("Sword");
            SwordReal.SetActive(false);
            SwordFake.SetActive(true);
        }
    }


   
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

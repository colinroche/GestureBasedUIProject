using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class MainMenuGemBehaviour : MonoBehaviour
{
    [SerializeField]  Rigidbody mainMenuGemRb;
    private bool pauseMenuBool = false;
    private int gemRotateVal = 0;

    private int removeGems = 0;
    [SerializeField] GameObject gem;

    [SerializeField] GameObject mainMenuGems;
    [SerializeField] GameObject levelSelectGems;
    [SerializeField] GameObject timeText;
    [SerializeField] GameObject spawnGems;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] Animation anim;
    [SerializeField] AudioClip gemHitSFX;
    [SerializeField] AudioClip gemBreakSFX;
    private ParticleSystem gemExplosion;

    public float speed;
    public float angularSpeed;
    private float triggerCount = 0;

    public SpawnManager spawnManager;

    public void Start()
    {
        mainMenuGemRb = GetComponent<Rigidbody>();
        gemRotateVal = 1;
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
                triggerCount = 0;
                gemExplosion = GetComponent<ParticleSystem>();
                audioSrc.PlayOneShot(gemBreakSFX);
                gemExplosion.Play();
                
                 // Main Menu
                if(gem.tag == "Play"){
                    print("play");
                    mainMenuGems.SetActive(false);
                    levelSelectGems.SetActive(true);
                    anim.Play();
                }else if(gem.tag == "Exit"){
                    print("exit");
                }
                 // Level Select
                else if(gem.tag == "Classic"){
                    print("classic");
                    Destroy(gameObject, 2.0f);
                    SceneManager.LoadScene(1);
                }else if(gem.tag == "Arcade"){
                    print("arcade");
                    Destroy(gameObject, 2.0f);
                    SceneManager.LoadScene(2);
                }else if(gem.tag == "Zen"){
                    print("zed mode");
                    Destroy(gameObject, 2.0f);
                    SceneManager.LoadScene(3);
                }
                 // Game Gems
                else if(gem.tag == "Start"){
                    print("Start mode");
                    StartCoroutine(RemoveMenuGems());
                    spawnGems.SetActive(true);
                    spawnManager.SpawningGame();
                }else if(gem.tag == "StartArcade"){
                    print("Start mode");
                    StartCoroutine(RemoveMenuGems());
                    spawnGems.SetActive(true);
                    spawnManager.SpawningGame();
                    StartCoroutine(StartTimer());
                    timeText.SetActive(true);
                    FindObjectOfType<GameSession>().StartTimer();
                }else if(gem.tag == "MainMenu"){
                    print("MainMenu mode");
                   SceneManager.LoadScene(0);
                }

            }
            gemRotateVal = gemRotateVal + 20;
        }
    }

    IEnumerator RemoveMenuGems()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Working");
        mainMenuGems.SetActive(false);
    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1.0f);
        timeText.SetActive(true);
    }


}

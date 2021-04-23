using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class MainMenuGemBehaviour : MonoBehaviour
{
    [SerializeField]  Rigidbody mainMenuGemRb;
    private bool pauseMenuBool = true;
    private int gemRotateVal = 0;
    [SerializeField] GameObject gem;

    [SerializeField] GameObject mainMenuGems;
    [SerializeField] GameObject levelSelectGems;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] Animation anim;
    [SerializeField] AudioClip gemHitSFX;
    [SerializeField] AudioClip gemBreakSFX;
    private ParticleSystem gemExplosion;


    public float speed;
    public float angularSpeed;
    private float triggerCount = 0;

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
                if(gem.tag == "Play"){
                    print("play");
                    mainMenuGems.SetActive(false);
                    levelSelectGems.SetActive(true);
                    anim.Play();
                }else if(gem.tag == "Volume"){
                    print("volume");
                    mainMenuGems.SetActive(false);
                    levelSelectGems.SetActive(true);
                    anim.Play();
                }else if(gem.tag == "Exit"){
                    print("exit");
                }else if(gem.tag == "Classic"){
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

            }
            gemRotateVal = gemRotateVal + 20;
        }
        
    }

 

 



}

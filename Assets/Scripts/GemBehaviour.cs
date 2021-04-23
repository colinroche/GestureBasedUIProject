using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem gemExplosion;
    [SerializeField] GameObject gem;
    [SerializeField] AudioClip gemBreakSFX;

    [SerializeField] AudioSource audioSrc;
    [SerializeField] Animation anim;
    private float speed = 1f;
    private float rotateSpeed = 100f;
    private int gemValue = 0;
    
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        this.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.up * Time.deltaTime* speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MaxHeight")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(GemSpeed());
        }

        if (other.tag == "Sword")
        {
            if (gameObject.tag == "White")
            {
                gemValue = 5;
                gemExplosion = GetComponent<ParticleSystem>();
                audioSrc.PlayOneShot(gemBreakSFX);
                gemExplosion.Play();
            }
            else if (gameObject.tag == "Yellow")
            {
                gemValue = 10;
                gemExplosion = GetComponent<ParticleSystem>();
                audioSrc.PlayOneShot(gemBreakSFX);
                gemExplosion.Play();
            }
            else if (gameObject.tag == "Blue")
            {
                gemValue = 20;
                gemExplosion = GetComponent<ParticleSystem>();
                audioSrc.PlayOneShot(gemBreakSFX);
                gemExplosion.Play();
            }
            else if (gameObject.tag == "Purple")
            {
                gemValue = 50;
                gemExplosion = GetComponent<ParticleSystem>();
                audioSrc.PlayOneShot(gemBreakSFX);
                gemExplosion.Play();
            }
            else if (gameObject.tag == "Bomb")
            {
                gemValue = 0;
                FindObjectOfType<GameSession>().BombCheck();
            }
            FindObjectOfType<GameSession>().AddScore(gemValue);
            Destroy(gameObject, 0.25f);
        }
    }

    IEnumerator GemSpeed()
    {
        speed = 0.5f;
        yield return new WaitForSeconds(0.3f);
        speed = 0f;
    }

}

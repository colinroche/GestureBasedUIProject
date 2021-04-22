using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
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
            }
            else if (gameObject.tag == "Yellow")
            {
                gemValue = 10;
            }
            else if (gameObject.tag == "Blue")
            {
                gemValue = 20;
            }
            else if (gameObject.tag == "Purple")
            {
                gemValue = 50;
            }
            FindObjectOfType<GameSession>().AddScore(gemValue);
            Destroy(gameObject);
        }
    }

    IEnumerator GemSpeed()
    {
        speed = 0.5f;
        yield return new WaitForSeconds(0.3f);
        speed = 0f;
    }

}

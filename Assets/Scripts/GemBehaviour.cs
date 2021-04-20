using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    private float speed = 1f;
    private float rotateSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.up * Time.deltaTime* speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MaxHeight")
        {
            speed = 0f;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeExplosion : MonoBehaviour
{
    [SerializeField] ParticleSystem gemExplosion;

    // Start is called before the first frame update
    void Start()
    {
        gemExplosion.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

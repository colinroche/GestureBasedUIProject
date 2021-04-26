using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    GameSpawn gameSpawn;
    // Start is called before the first frame update
    void Start()
    {
        gameSpawn = GetComponent<GameSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawningGame()
    {
        Debug.Log("Checker");
        gameSpawn.LevelCheck();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSpawn : MonoBehaviour
{
    GemSpawner gemSpawner;
    SpawnLevel spawnLevel;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        gemSpawner = GetComponent<GemSpawner>();
        spawnLevel = GetComponent<SpawnLevel>();
    }

    // Calling the spawning for the appropriate level by checking the scene
    public void LevelCheck()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            spawnLevel.FirstLevelSpawning();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            spawnLevel.SecondLevelSpawning();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            spawnLevel.ThirdLevelSpawning();
        }
    }
}

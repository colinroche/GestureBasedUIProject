using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawn : MonoBehaviour
{
    GemSpawner gemSpawner;
    SpawnLevel spawnLevel;

    private Vector3 position;
    private int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        gemSpawner = GetComponent<GemSpawner>();
        spawnLevel = GetComponent<SpawnLevel>();
    }

    public void Level1()
    {
        LevelCheck();
    }

    private void LevelCheck()
    {
        if (level == 1)
        {
            spawnLevel.FirstLevelSpawning();
        }
    }

    public void LevelChange()
    {
        level++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

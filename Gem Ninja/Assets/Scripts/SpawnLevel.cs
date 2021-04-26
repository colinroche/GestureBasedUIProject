using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    GemSpawner gemSpawner;

    private int numGems = 0;
    private int gemMax = 5;
    private int numBombs = 7;
    private int numClocks = 4;
    private float time;
    private int numSpawn = 2;

    private int check;
    private float timeCheck;


    // Start is called before the first frame update
    void Start()
    {
        gemSpawner = GetComponent<GemSpawner>();
    }

    // Spawning for Classic Mode
    public void FirstLevelSpawning()
    {
        numGems = 50;
        time = 1.2f;
        gemSpawner.GemWhiteSpawner(numGems, time);

        numGems = 20;
        time = 3f;
        gemSpawner.GemYellowSpawner(numGems, time);

        numGems = 10;
        time = 6f;
        gemSpawner.GemBlueSpawner(numGems, time);

        numGems = 5;
        time = 10f;
        gemSpawner.GemPurpleSpawner(numGems, time);

        time = 8f;
        gemSpawner.BombSpawner(numBombs, time);
    }

    // Spawning for Arcade Mode
    public void SecondLevelSpawning()
    {
        numGems = 50;
        time = 1.2f;
        gemSpawner.GemWhiteSpawner(numGems, time);

        numGems = 20;
        time = 3f;
        gemSpawner.GemYellowSpawner(numGems, time);

        numGems = 10;
        time = 6f;
        gemSpawner.GemBlueSpawner(numGems, time);

        numGems = 5;
        time = 10f;
        gemSpawner.GemPurpleSpawner(numGems, time);

        time = 15f;
        gemSpawner.ClockSpawner(numClocks, time);
    }

    // Spawning for Zen Mode
    public void ThirdLevelSpawning()
    {
        check = 1; 
        time = 0f;
        StartCoroutine(MultiSpawnTimer(time, numSpawn, check));

        check = 2; 
        time = 14f;
        StartCoroutine(MultiSpawnTimer(time, numSpawn, check));

        check = 3; 
        time = 28f;
        StartCoroutine(MultiSpawnTimer(time, numSpawn, check));

        check = 4; 
        time = 42f;
        StartCoroutine(MultiSpawnTimer(time, numSpawn, check));
    }

    // Increments the amount of gems spawned starting with 1 until it reaches 4
    IEnumerator MultiSpawnTimer(float time, int numSpawn, int check)
    {
        yield return new WaitForSeconds(time);
        for(int spawnCount = 0; spawnCount < numSpawn; spawnCount++)
        {
            for (int gemCheck = 0; gemCheck < gemMax; gemCheck++)
            {
                if (gemCheck == gemMax)
                {
                    gemCheck = 0;
                }
                yield return new WaitForSeconds(1.7f);
                GemChecker(gemCheck, check);
            }
        }
    }

    // Calling the different types of gems
    private void GemChecker(int gemCheck, int check)
    {
        if (check == 1)
        {
           gemSpawner.GemWhiteSpawner(gemCheck, 0f); 
        }
        else if (check == 2)
        {
           gemSpawner.GemYellowSpawner(gemCheck, 0f); 
        }
        else if (check == 3)
        {
           gemSpawner.GemBlueSpawner(gemCheck, 0f); 
        }
        else if (check == 4)
        {
           gemSpawner.GemPurpleSpawner(gemCheck, 0f); 
        }
    }
}

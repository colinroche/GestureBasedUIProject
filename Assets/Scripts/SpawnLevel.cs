using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    GemSpawner gemSpawner;

    private int numGems = 0;


    // Start is called before the first frame update
    void Start()
    {
        gemSpawner = GetComponent<GemSpawner>();
    }

    public void FirstLevelSpawning()
    {
        numGems = 50;

        gemSpawner.GemWhiteSpawner(numGems);

        numGems = 20;
        gemSpawner.GemYellowSpawner(numGems);

        numGems = 10;
        gemSpawner.GemBlueSpawner(numGems);

        numGems = 5;
        gemSpawner.GemPurpleSpawner(numGems);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] Transform parentItem;
    private Vector3 position;

    private float sideOffset = 1f;
    private float forwardOffset;

    private float check1 = 0.5f;
    private float check2 = 0.75f;

    private float time;

    private int whiteGem = 5;
    private int yellowGem = 10;
    private int blueGem = 20;
    private int purpleGem = 50;

    private int numGems = 0;

    [SerializeField] GameObject player;

    public void Spawner(Transform transform, int numOfObjects, float time)
    {
        StartCoroutine(SpawnTimer(transform, numOfObjects, time));
    }
    
    // Spawns the relevent object in a semi-circle around the player
    IEnumerator SpawnTimer(Transform transform, int numOfObjects, float time)
    {
        int spawned = 0;
        while (spawned < numOfObjects)
        {
            yield return new WaitForSeconds(time);
            float posX = Random.Range(-sideOffset, sideOffset);
            
            if (posX > check2 || posX < -check2)
            {
                forwardOffset = 0.5f;
            }
            else if (posX > check1 || posX < -check1)
            {
                forwardOffset = 0.75f;
            }
            else {
                forwardOffset = 1.0f;
            }
            
            position = new Vector3(posX, 0.2f, forwardOffset);
            spawned++;

            Transform spawn = Instantiate(transform, position, Quaternion.identity);
            spawn.parent = parentItem;
            //Destroy(spawn.gameObject, 10.0f);
        }    
    }

    // Methods for spawning the relevent gems/bombs/clocks.

    public void GemWhiteSpawner(int numGems, float time)
    {
        Transform gems;
        gems = GameObject.Find("GemWhite").transform;
        Spawner(gems, numGems, time);
    }

    public void GemYellowSpawner(int numGems, float time)
    {
        Transform gems;
        gems = GameObject.Find("GemYellow").transform;
        Spawner(gems, numGems, time);
    }

    public void GemBlueSpawner(int numGems, float time)
    {
        Transform gems;
        gems = GameObject.Find("GemBlue").transform;
        Spawner(gems, numGems, time);
    }

    public void GemPurpleSpawner(int numGems, float time)
    {
        Transform gems;
        gems = GameObject.Find("GemPurple").transform;
        Spawner(gems, numGems, time);
    }

    public void BombSpawner(int numBombs, float time)
    {
        Transform bombs;
        bombs = GameObject.Find("Bomb").transform;
        Spawner(bombs, numBombs, time);
    }

    public void ClockSpawner(int numClocks, float time)
    {
        Transform clocks;
        clocks = GameObject.Find("Clock").transform;
        Spawner(clocks, numClocks, time);
    }
}

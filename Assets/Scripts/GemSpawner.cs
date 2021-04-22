using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] Transform parentItem;
    private Vector3 position;

    private float sideOffset = 1.5f;
    private float forwardOffset = 1f;

    private float time;

    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawner(Transform transform, int numOfObjects, float time)
    {
        StartCoroutine(SpawnTimer(transform, numOfObjects, time));
    }

    IEnumerator SpawnTimer(Transform transform, int numOfObjects, float time)
    {
        int spawned = 0;
        while (spawned < numOfObjects)
        {

            float leftRange = player.transform.position.x - sideOffset;
            float rightRange = player.transform.position.x + sideOffset;
            float forwardRange =  player.transform.position.z + forwardOffset;

            yield return new WaitForSeconds(time);
            position = new Vector3(Random.Range(rightRange, leftRange),0.2f, forwardRange);
            spawned++;

            Transform spawn = Instantiate(transform, position, Quaternion.identity);
            spawn.parent = parentItem;
            //Destroy(spawn.gameObject, 10.0f);
        }    
    }

    public void GemWhiteSpawner(int numGems)
    {
        time = 1.2f;
        Transform gems;
        gems = GameObject.Find("GemWhite").transform;
        Spawner(gems, numGems, time);
    }

    public void GemYellowSpawner(int numGems)
    {
        time = 3f;
        Transform gems;
        gems = GameObject.Find("GemYellow").transform;
        Spawner(gems, numGems, time);
    }

    public void GemBlueSpawner(int numGems)
    {
        time = 6f;
        Transform gems;
        gems = GameObject.Find("GemBlue").transform;
        Spawner(gems, numGems, time);
    }

    public void GemPurpleSpawner(int numGems)
    {
        time = 10f;
        Transform gems;
        gems = GameObject.Find("GemPurple").transform;
        Spawner(gems, numGems, time);
    }
}

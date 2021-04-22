using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] Transform parentItem;
    private Vector3 position;

    private float sideOffset = 1.5f;
    private float forwardOffset = 1f;

    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawner(Transform transform, int numOfObjects)
    {
        StartCoroutine(SpawnTimer(transform, numOfObjects));
    }

    IEnumerator SpawnTimer(Transform transform, int numOfObjects)
    {
        int spawned = 0;
        while (spawned < numOfObjects)
        {
            float leftRange = player.transform.position.x - sideOffset;
            float rightRange = player.transform.position.x + sideOffset;
            float forwardRange =  player.transform.position.z + forwardOffset;
            position = new Vector3(Random.Range(rightRange, leftRange),0.2f, forwardRange);
            spawned++;

            Transform spawn = Instantiate(transform, position, Quaternion.identity);
            spawn.parent = parentItem;
            //Destroy(spawn.gameObject, 10.0f);
            yield return new WaitForSeconds(1.2f);
        }    
    }

     public void GemLowSpawner(int numGems)
    {
        Transform gems;
        gems = GameObject.Find("Gem").transform;
        Spawner(gems, numGems);
    }
}

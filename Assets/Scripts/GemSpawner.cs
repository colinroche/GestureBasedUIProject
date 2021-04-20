using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] Transform parentItem;
    private Vector3 position;
    private float offset;
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
        int spawned = 0;
        while (spawned < numOfObjects)
        {
            position = new Vector3(Random.Range(-6f, 2f),0.2f, 1f);
            spawned++;

            Transform spawn = Instantiate(transform, position, Quaternion.identity);
            spawn.parent = parentItem;
            //Destroy(spawn.gameObject, 10.0f);
        }    
    }

     public void GemLowSpawner(int numGems)
    {
        Transform gems;
        gems = GameObject.Find("Gem").transform;
        Spawner(gems, numGems);
    }
}

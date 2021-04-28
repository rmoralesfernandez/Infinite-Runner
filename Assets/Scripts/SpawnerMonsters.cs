using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMonsters : MonoBehaviour
{
    public GameObject[] floatingItemsPatterns;

    [SerializeField]
    private float timeBetweenItems = 10, increaseSpawn = 0, minSpawnTime = 0.65f;

    [SerializeField]
    private float maxNumItems = 0;

    private int rnd = 0;
    private int lengthFP;
    private float timeWaitNew = 1;
    private float itemsSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeWaitNew = timeBetweenItems;
        lengthFP = floatingItemsPatterns.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeWaitNew <= 0 && (maxNumItems == 0 || maxNumItems > itemsSpawned))
        {
            rnd = Random.Range(0, lengthFP);
            Instantiate(floatingItemsPatterns[rnd], transform.position, Quaternion.identity);
            if(increaseSpawn >= 0)
            {
                timeBetweenItems -= increaseSpawn;
                timeWaitNew = timeBetweenItems;
            }
            if(timeWaitNew < minSpawnTime)
            {
                timeWaitNew = minSpawnTime;
                itemsSpawned += 1;
            }
        } else
        {
            timeWaitNew -= Time.deltaTime;
        }
    }
}

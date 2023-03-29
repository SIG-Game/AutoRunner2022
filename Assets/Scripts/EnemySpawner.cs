using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    protected GameObject prefabToSpawn;
    [SerializeField]
    private float prefabSpawnInterval;
    [SerializeField]
    private int maxSpawnedPrefab;
    [SerializeField] 
    private Vector2 minSpawnPosition;
    [SerializeField] 
    private Vector2 maxSpawnPosition;

    private int numPrefabs;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        numPrefabs = 0;
        spawnTimer = 0f;
        if (numPrefabs < maxSpawnedPrefab)
        {
            SpawnPrefab();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numPrefabs >= maxSpawnedPrefab)
        {
            return;
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= prefabSpawnInterval)
        {
            spawnTimer = 0f;
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, new Vector2(Random.Range(minSpawnPosition.x, maxSpawnPosition.y), Random.Range(minSpawnPosition.x, maxSpawnPosition.y)), Quaternion.identity, transform);
        numPrefabs++;
    }
}

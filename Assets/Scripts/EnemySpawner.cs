using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private float enemySpawnIntervalSeconds;
    [SerializeField]
    private int maxSpawnedEnemies;
    [SerializeField]
    private Vector2 minSpawnPosition;
    [SerializeField]
    private Vector2 maxSpawnPosition;

    private int numEnemies;
    private float spawnTimer;

    private void Start()
    {
        numEnemies = 0;
        spawnTimer = 0f;

        if (numEnemies < maxSpawnedEnemies)
        {
            SpawnPrefab();
        }
    }

    private void Update()
    {
        if (numEnemies >= maxSpawnedEnemies)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= enemySpawnIntervalSeconds)
        {
            spawnTimer = 0f;
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y), 0f);

        GameObject spawnedEnemy = Instantiate(prefabToSpawn,
            spawnPosition, Quaternion.identity, transform);

        EnemyController spawnedEnemyController =
            spawnedEnemy.GetComponent<EnemyController>();
        spawnedEnemyController.SetPlayer(player);
        spawnedEnemyController.SetSpawner(this);

        numEnemies++;
    }

    public void SpawnedEnemyDestroyed()
    {
        numEnemies--;
    }
}

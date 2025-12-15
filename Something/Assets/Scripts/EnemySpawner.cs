using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public int spawnToken;

    public bool startSpawn;

    void Start()
    {
        startSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startSpawn) {SpawnEnemy(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startSpawn = true;
        }

    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < spawnToken; i++)
        {
            //select random enemy prefab
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            //select random spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //spawn enemies
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            spawnToken --;
        }
    }
}

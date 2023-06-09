using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRespawn3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform respawnPositionMin;
    public Transform respawnPositionMax;

    private bool isSpawning = false;
    private float elapsedTime = 0f;
    private float spawnInterval = 3f;
    private float startDelay = 10f;

    private void Start()
    {
        Invoke("StartSpawning", startDelay);
    }

    private void StartSpawning()
    {
        isSpawning = true;
        SpawnEnemy();
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        if (!isSpawning)
            return;

        Vector3 respawnPosition = new Vector3(
            Random.Range(respawnPositionMin.position.x, respawnPositionMax.position.x),
            Random.Range(respawnPositionMin.position.y, respawnPositionMax.position.y),
            Random.Range(respawnPositionMin.position.z, respawnPositionMax.position.z)
        );

        Instantiate(enemyPrefab, respawnPosition, Quaternion.identity);
    }
}

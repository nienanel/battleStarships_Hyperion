using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesRespawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform respawnPositionMin;
    public Transform respawnPositionMax;

    private bool isSpawning = false;
    private float elapsedTime = 0f;
    private float spawnInterval = 3f;

    private void Start()
    {
        isSpawning = true;
    }

    private void Update()
    {
        if (isSpawning)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= spawnInterval)
            {
                SpawnEnemy();
                elapsedTime = 0f;
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 respawnPosition = new Vector3(
            Random.Range(respawnPositionMin.position.x, respawnPositionMax.position.x),
            Random.Range(respawnPositionMin.position.y, respawnPositionMax.position.y),
            Random.Range(respawnPositionMin.position.z, respawnPositionMax.position.z)
        );

        Instantiate(enemyPrefab, respawnPosition, Quaternion.identity);
    }
}

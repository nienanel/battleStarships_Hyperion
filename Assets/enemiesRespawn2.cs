using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesRespawn2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform respawnPositionMin;
    public Transform respawnPositionMax;

    private bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(30f); // Esperar 1 minuto

        isSpawning = true;

        while (isSpawning)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(10f); // Esperar 10 segundos
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

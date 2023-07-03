using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int numberOfEnemies;
    public float spawnInterval;
    private float nextSpawn;

    private void Start()
    {
        nextSpawn = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (numberOfEnemies > 0 || Time.time >= nextSpawn)
        {
            SpawnEnemies();
            numberOfEnemies--;
            nextSpawn = Time.time + spawnInterval;
        }
    }
    public void SpawnEnemies()
    {
        GameObject enemyShip = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        //EnemyShip enemyShipScript = enemyShip.GetComponent<EnemyShip>();
        //enemyShipScript.startPoint = transform.position;
    }
}
           
    




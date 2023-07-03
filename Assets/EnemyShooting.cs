using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform shootingTransform;
    public float laserSpeed = 50f;
    public float minShootDelay = 1f;
    public float maxShootDelay = 5f;

    private float nextShootTime;

    private void Start()
    {
        SetNextShootTime();
    }

    private void Update()
    {
        if (Time.time >= nextShootTime)
        {
            Shoot();
            SetNextShootTime();
        }
    }

    private void Shoot()
    {
        Vector3 direction = -(transform.position - shootingTransform.position).normalized;

        GameObject laser = Instantiate(laserPrefab, shootingTransform.position, shootingTransform.rotation);

        Rigidbody laserRb = laser.GetComponent<Rigidbody>();
        laserRb.velocity = transform.forward* laserSpeed;
    }

    private void SetNextShootTime()
    {
        float randomDelay = Random.Range(minShootDelay, maxShootDelay);
        nextShootTime = Time.time + randomDelay;
    }
}

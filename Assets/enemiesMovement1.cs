using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesMovement1 : MonoBehaviour
{
    public float movementSpeed = 50f;
    public float movementRange = 170f;

    private Vector3 movementDirection;
    private float initialZPosition;

    private void Start()
    {
        initialZPosition = transform.position.z;

        StartRandomMovement();
    }

    private void Update()
    {
        float newZPosition = transform.position.z - (-movementDirection.z * movementSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);
    }

    private void StartRandomMovement()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 0f); 
        float clampedX = Mathf.Clamp(randomX, -1f, 1f);
        float clampedZ = Mathf.Clamp(randomZ, -1f, 0f);
        movementDirection = new Vector3(clampedX, 0f, clampedZ).normalized;
    }
}

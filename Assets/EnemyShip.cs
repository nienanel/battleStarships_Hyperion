using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 5f;
    public float startX = 10f;
    public float targetX = -10f;

    private bool hasSpawned;

    private void Start()
    {
        transform.Rotate(0f, -90f, 0f);
    }
    private void Update()
    {
        if (!hasSpawned)
        {
            Move();
        }
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        float pivotRange = 100f;
        float pivotSpeed = 10f;

        Vector3 targetPositionX = new Vector3(targetX, transform.position.y, transform.position.z);

        float targetPositionZ = Mathf.Sin(Time.time * pivotSpeed) * pivotRange + transform.position.z;

        Vector3 targetPosition = new Vector3(targetPositionX.x, targetPositionX.y, targetPositionZ);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position.x <= targetX)
        {
            Destroy(this.gameObject);
            hasSpawned = true;
        }
    }


}

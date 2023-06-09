using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed = 450f;
    public float limitZ = 180f;

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalMove, 0, verticalMove);
        Vector3 directionMove = direction * playerSpeed * Time.deltaTime;
        Vector3 directionLimit = transform.position + directionMove;

        directionLimit.z = Mathf.Clamp(directionLimit.z, -limitZ, limitZ);

        transform.position = directionLimit;
    }
}

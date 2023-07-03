using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float maxZ = 11f;
    public float minZ = -9f;

    public float rotationSpeed = 10f;

    public List<Transform> gunTransforms;
    private int currentGunIndex = 0; 
    public GameObject laserPrefab;
    public float laserSpeed = 100f;


    public delegate void ShootDelegate();
    public static event ShootDelegate OnShoot;
    private void Update()
    {
        float zMovement = -Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;


        // limite de movimiento en z
        float currentZ = transform.position.z;
        float newZ = currentZ + zMovement;
        newZ = Mathf.Clamp(newZ, minZ, maxZ);

        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        // rotacion en x del player
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(transform.position, Vector3.left, rotationSpeed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(transform.position, Vector3.right, rotationSpeed);
        }

        //shooting 
        if (Input.GetKeyDown(KeyCode.Space))
        {      
            OnShoot?.Invoke();

            Transform currentGunTransform = gunTransforms[currentGunIndex];

            GameObject laser = Instantiate(laserPrefab, currentGunTransform.position, currentGunTransform.rotation);

            laser.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentGunTransform.rotation.eulerAngles.y, currentGunTransform.rotation.eulerAngles.z);

            Rigidbody laserRb = laser.GetComponent<Rigidbody>();
            laserRb.velocity = transform.forward * laserSpeed;

            currentGunIndex = (currentGunIndex + 1) % gunTransforms.Count;
        }
    }
}

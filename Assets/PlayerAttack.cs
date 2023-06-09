using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody laser;
    public Transform gun;
    public Transform gun2;
    public float firePower = 20f;

    private Rigidbody[] laserArray = new Rigidbody[12];
    private int lasersShot = 0;
    private float shootInterval = 0.5f;
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && lasersShot < laserArray.Length && elapsedTime >= shootInterval)
        {
            Fire();
            elapsedTime = 0f;
        }

        if (lasersShot == laserArray.Length)
        {
            DestroyBullets();
        }
    }

    public void Fire()
    {
        Rigidbody laserInstance1;
        Rigidbody laserInstance2;

        laserInstance1 = Instantiate(laser, gun.position, Quaternion.Euler(90f, 0f, 0f));
        laserInstance1.AddForce(gun.forward * 500 * firePower);

        laserInstance2 = Instantiate(laser, gun2.position, Quaternion.Euler(90f, 0f, 0f));
        laserInstance2.AddForce(gun2.forward * 500 * firePower);

        laserArray[lasersShot] = laserInstance1;
        lasersShot++;

        laserArray[lasersShot] = laserInstance2;
        lasersShot++;
    }

    void DestroyBullets()
    {
        for (int i = 0; i < laserArray.Length; i++)
        {
            if (laserArray[i] != null)
            {
                Destroy(laserArray[i].gameObject);
            }
        }

        lasersShot = 0;
    }
}

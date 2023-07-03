using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float activationTime;

    private GameManager gameManager;
    public int damage = 1;

    private void Start()
    {
        activationTime = Time.time;
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        LayerMask playerLayer = LayerMask.NameToLayer("Player");
        LayerMask enemyLayer = LayerMask.NameToLayer("Enemy");
        LayerMask enemyLayer2 = LayerMask.NameToLayer("Enemy2");
        LayerMask enemyLaserLayer = LayerMask.NameToLayer("EnemyLaser");
        LayerMask playerLaserLayer = LayerMask.NameToLayer("PlayerLaser");

        if (collision.gameObject.layer == enemyLaserLayer && gameObject.layer == playerLayer)
        {
            Destroy(collision.gameObject);
            gameManager.TakeDamage(damage);
            Debug.Log("Collision with player");
        }
        else if (collision.gameObject.layer == playerLaserLayer && (gameObject.layer == enemyLayer || gameObject.layer == enemyLayer2))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            if (gameObject.layer == enemyLayer)
            {
                gameManager.AddPoints(10);
            }
            else if (gameObject.layer == enemyLayer2)
            {
                gameManager.AddPoints(20);
            }
            Debug.Log("Collision with enemy");
        }
    }

    public bool HasBeenActiveFor(float duration)
    {
        float elapsedTime = Time.time - activationTime;

        //return elapsedTime >= duration;
        return Time.time - activationTime >= duration;
    }
}

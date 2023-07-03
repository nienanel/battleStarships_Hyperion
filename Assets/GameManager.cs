using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float gameStartTime;
    private float laserBeanDestroyTime = 5f;

    //score sistem
    public Text scoreText;
    public Text maxScoreText;
    public Text livesText;

    private int score = 0;
    private static int maxScore = 0;
    private int currentlives = 0;
    private int maxLives = 3;

    public GameObject gameOverScreen;
    public float gameOverDelay = 3f;

    void Start()
    {
        gameStartTime = Time.time;
        currentlives = maxLives;
        score = 0;
        print(gameStartTime);

        UpdateScore();
        UpdateLives();
    }

    void Update()
    {
        if (Time.time - gameStartTime >= laserBeanDestroyTime)
        {
            DestroyLaserBeans();
        }
    
    }

    void DestroyLaserBeans()
    {
        GameObject[] laserBeans = GameObject.FindGameObjectsWithTag("LaserBean");

        foreach (GameObject laserBean in laserBeans)
        {
            Laser laserScript = laserBean.GetComponent<Laser>();
            if (laserScript != null && laserScript.HasBeenActiveFor(3f))
            {
                Destroy(laserBean);
            }
        }
    }

    /// sistema de vidas y score
    public void AddPoints(int points)
    {
        score += points;
        UpdateScore();
    }

    public void EnemyDestroyed(bool isBoss)
    {
        int points = isBoss ? 20 : 10;
        AddPoints(points);
    }

    public void TakeDamage(int damage)
    {
        currentlives -= damage;
        UpdateLives();

        if (currentlives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateLives()
    {
        livesText.text = "Vidas: " + currentlives.ToString();
    }

    private void GameOver()
    {
        if (score > maxScore)
        {
            maxScore = score;
        }

        maxScoreText.text = "Max Score: " + maxScore.ToString();

        // Guardar la puntuación máxima en PlayerPrefs para que persista en futuras partidas
        PlayerPrefs.SetInt("MaxScore", maxScore);
        PlayerPrefs.Save();

        print("game over");
        Invoke("RestartGame", gameOverDelay);
        gameOverScreen.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0); // Carga la escena inicial
    }
}

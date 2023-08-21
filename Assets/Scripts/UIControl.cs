using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    GameObject gameNameText = default;


    [SerializeField]
    GameObject gameOverText = default;

    [SerializeField]
    Text scoreText = default;

    [SerializeField]
    GameObject playButton = default;

    int score;
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }
    public void GameHasStarted()
    {
        score = 0;
        gameNameText.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
    }

    void UpdateScore()
    {
        scoreText.text = "SCORE: " + scoreText;
    }

    public void AsteroidHasDestroyed(GameObject asteroid)
    {
        switch (asteroid.gameObject.name[8])
        {
            case '1':
                score += 5;
                UpdateScore();
                break;
            case '2':
                score += 10;
                UpdateScore();
                break;
            case '3':
                score += 15;
                UpdateScore();
                break;
        }
    }
}

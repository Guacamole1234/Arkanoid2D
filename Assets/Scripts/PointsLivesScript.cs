using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsLivesScript : MonoBehaviour
{
    public static PointsLivesScript instance;

    [SerializeField] private int currentScore;
    [SerializeField] private int currentLives;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        currentScore = 0;

        livesText.text = currentLives.ToString("00");
    }

    public void UpdateScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;
        scoreText.text = currentScore.ToString("0000");
    }

    public void UpdateLives(int livesToAdd)
    {
        currentLives += livesToAdd;
        livesText.text = currentLives.ToString("00");

        if (currentLives <= 0)
        {
            LoseGame();
        }
    }

    private void LoseGame()
    {
        loseCanvas.SetActive(true);
    }
}

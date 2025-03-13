using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsLivesScript : MonoBehaviour
{
    public static PointsLivesScript instance;

    [SerializeField] private int currentScore;
    [SerializeField] private int currentLives;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;

    [SerializeField] private TextMeshProUGUI winPointsText;
    [SerializeField] private TextMeshProUGUI losePointsText;

    [SerializeField] private Transform bricks;
    private float bricksAmount;

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

        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);

        bricksAmount = bricks.childCount;
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
        losePointsText.text = currentScore.ToString();
        loseCanvas.SetActive(true);
    }

    public void CheckBricks()
    {
        bricksAmount--;

        if (bricksAmount <= 0)
        {
            winPointsText.text = currentScore.ToString();
            winCanvas.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

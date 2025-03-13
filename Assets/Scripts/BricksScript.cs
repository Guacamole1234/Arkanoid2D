using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BricksScript : MonoBehaviour
{
    [SerializeField] private int brickLives;
    [SerializeField] private int brickPoints;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            brickLives--;

            if (brickLives <= 0)
            {
                PointsLivesScript.instance.UpdateScore(brickPoints);
                PointsLivesScript.instance.CheckBricks();
                PlayerScript.instance.PowerUpSpawn(transform.position);
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
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
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDeleteScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RestartBall"))
        {
            Destroy(gameObject);
        }
    }
}

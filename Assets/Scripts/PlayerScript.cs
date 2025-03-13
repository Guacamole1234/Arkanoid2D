using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    [SerializeField] private float playerSpeed;

    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    public bool gameStart;

    public bool powerUpInverted;
    float playerDirection;

    void Awake()
    {
        if (PlayerScript.instance == null)
        {
            PlayerScript.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        gameStart = true;
    }

    void Update()
    {
        if (gameStart)
        {
            Vector3 newPosition = gameObject.transform.position;

            playerDirection = Input.GetAxisRaw("Horizontal");

            if (powerUpInverted)
            {
                playerDirection = -playerDirection;
            }

            newPosition.x = Mathf.Clamp(newPosition.x + (playerDirection) * playerSpeed * Time.deltaTime, leftLimit, rightLimit);

            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Slow"))
        {
            Destroy(collision.gameObject);
            //PowerUpsBehaviour.instance.CallSlowBall();
        }

        if (collision.gameObject.name.Contains("Inverted"))
        {
            Destroy(collision.gameObject);
            //PowerUpsBehaviour.instance.CallInvertedCroc();
        }
    }
}

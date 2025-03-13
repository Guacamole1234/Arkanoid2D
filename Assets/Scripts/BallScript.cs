using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public static BallScript instance;

    [HideInInspector] public Rigidbody2D ballRigidbody;

    [SerializeField] private float ballSpeed;

    private bool ballOut;

    [SerializeField] private Transform playerObject;

    [SerializeField] private float minMaxLaunchValues;

    [SerializeField] private Vector2 spawnPosition;

    void Awake()
    {
        if (BallScript.instance == null)
        {
            BallScript.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballOut = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !ballOut)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        if (PlayerScript.instance.gameStart)
        {
            gameObject.transform.parent = null;
            Vector2 capyBallVector = new Vector2(Random.Range(-minMaxLaunchValues, minMaxLaunchValues), 1f);
            ballRigidbody.velocity = capyBallVector.normalized * ballSpeed;
            ballOut = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("RestartBall"))
        {
            ModifyDirection();
        }
        else
        {
            Restart();
        }
    }

    public void Restart()
    {
        PointsLivesScript.instance.UpdateLives(-1);

        ballRigidbody.velocity = Vector2.zero;
        gameObject.transform.parent = playerObject;
        gameObject.transform.localPosition = spawnPosition;
        ballOut = false;
    }

    void ModifyDirection()
    {
        float modifiedAddedV = 1f;
        float minimumV = 0.5f;

        if (Mathf.Abs(ballRigidbody.velocity.x) < minimumV)
        {
            modifiedAddedV = Random.value < 0.5f ? modifiedAddedV : -modifiedAddedV;
            ballRigidbody.velocity += new Vector2(modifiedAddedV, 0f);
        }
        if (Mathf.Abs(ballRigidbody.velocity.y) < minimumV)
        {
            modifiedAddedV = Random.value < 0.5f ? modifiedAddedV : -modifiedAddedV;
            ballRigidbody.velocity += new Vector2(0f, modifiedAddedV);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    [SerializeField] private float playerSpeed;

    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;

    [SerializeField] private float invertedPowerupDuration;

    public bool gameStart;

    public bool powerUpInverted;
    private float playerDirection;

    [SerializeField] private float minimumChance;
    [SerializeField] private float maximumChance;

    [SerializeField] private GameObject invertedPUPrefab;

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
        if (collision.gameObject.CompareTag("PowerUpI"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(InvertedPlayer());
        }
    }

    private IEnumerator InvertedPlayer()
    {
        powerUpInverted = true;
        yield return new WaitForSeconds(invertedPowerupDuration);
        powerUpInverted = false;
        yield return null;
    }

    public void PowerUpSpawn(Vector3 spawnPUPos)
    {
        if (Random.Range(0f, 1f) <= Random.Range(minimumChance, maximumChance))
        {
            Instantiate(invertedPUPrefab, spawnPUPos, Quaternion.identity);
        }
    }
}

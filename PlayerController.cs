using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public float jumpForce = 100;

    private Rigidbody playerRb;
    private SpawnManager spawnManager;
    private GameManager gameManage;

    public Vector3 platformMidPoint;

    private float verticalInput;
    private float horizontalInput;
    private bool isOnGround;

    public bool isBossAlive;
    public bool isActive;
    public int powerUpStrength = 1;
    public int score;
    public int enemiesToSpawn = 1;

    
    

    void Start()
    {
        //Initiliazing variables
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        gameManage = GameObject.Find("Game Manager").GetComponent<GameManager>();
        isBossAlive = true;

        score = 0;
    }

        //Player Controls and Game Winning Condition
    void Update()
    {
        PlayerControlSetup();

        if (!isBossAlive)
        {
            EndOfGame();
        }
       
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //Prevent to other collisions and double jumping
        if (collision.gameObject.tag == "Platform")
        {
            isOnGround = true;
                  
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Collision power setup with power ups.
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Boss Platform")
        {
            gameManage.ScoreToAdd(1);
            SpawnSettings();
        }
        else if(other.gameObject.name == "Boss Platform") // Boss activated.
        {
            spawnManager.SpawnBoss();

        }

        if(other.gameObject.name == "Plane")    //Game over condition
        {
            gameManage.GameOver();
        }

    }

    void SpawnSettings()
    {
        if (enemiesToSpawn <= 3)
        {
            spawnManager.SpawnEnemies(enemiesToSpawn);
            enemiesToSpawn++;

        }
        else
        {
            enemiesToSpawn = 1;
            spawnManager.SpawnEnemies(enemiesToSpawn);
            enemiesToSpawn++;
        }

    }

    void PlayerControlSetup()
    {
        if (isActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(new Vector3(0, 0, 1) * speed * horizontalInput, ForceMode.Impulse);
            verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(new Vector3(1, 0, 0) * speed * -verticalInput, ForceMode.Impulse);

            platformMidPoint = transform.position;


            if (Input.GetKeyDown(KeyCode.Space) & isOnGround) //Prevent to double jumping
            {
                playerRb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
       
    }

    public void EndOfGame()
    {
        gameManage.WinningScreen();
    }
}


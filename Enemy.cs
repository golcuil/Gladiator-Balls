using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float enemySpeed;

    private Rigidbody enemyRb;
    private GameObject player;
    private GameManager gameManager;

    public int pointsToAdd;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 distance = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(distance * enemySpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (gameObject.CompareTag("Boss")) // if boss dies, let the game manager know
            {
                GameObject.Find("Player").GetComponent<PlayerController>().isBossAlive = false;
            }

            Destroy(gameObject);
            gameManager.ScoreToAdd(pointsToAdd);
           
        }
    }
}

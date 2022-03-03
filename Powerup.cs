using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.name == "Powerup1")
        {
            Destroy(gameObject);
            playerController.jumpForce = 200;
            playerController.powerUpStrength = 5;
        }
        if(other.CompareTag("Player") && gameObject.name == "Powerup2")
        {
            Destroy(gameObject);
            playerController.powerUpStrength = 10;
            playerController.jumpForce = 300;
        }

        if (other.CompareTag("Player") && gameObject.name == "Powerup3")
        {
            Destroy(gameObject);
            playerController.powerUpStrength = 15;
            playerController.jumpForce = 400;
        }

    }
}

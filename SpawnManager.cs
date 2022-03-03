using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    private PlayerController platformPos;



    private float platformPosX;
    private float platformPosZ;
    private float platformPosY;
    private float score;
    private float randDist = 0.5f;
    private int enemyCount;


    void Start()
    {
        platformPos = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    void Update()
    {
        platformPosX = platformPos.platformMidPoint.x;
        platformPosZ = platformPos.platformMidPoint.z;
        platformPosY = platformPos.platformMidPoint.y;
        score = GameObject.Find("Game Manager").GetComponent<GameManager>().score;
        enemyCount = FindObjectsOfType<Enemy>().Length;
    }

    //To make game harder.
    public void SpawnEnemies(int spawnNumber)
    {
        if (enemyCount == 0)
        {
            if (score < 25)
            {              
                for(int i = 1; i <= spawnNumber; i++)
                {
                    randDist = Random.Range(0, 10);
                    Instantiate(enemies[0], new Vector3(platformPosX, platformPosY + randDist, platformPosZ), enemies[0].transform.rotation);
                }
                
            }

            else if (score > 25 && score < 45)
            {
                for (int i = 1; i <= spawnNumber; i++)
                {
                    randDist = Random.Range(0, 10);
                    Instantiate(enemies[1], new Vector3(platformPosX, platformPosY + randDist, platformPosZ), enemies[1].transform.rotation);
                }
                    
            }

            else if (score >45)
            {
                for (int i = 1; i <= spawnNumber; i++)
                {
                    randDist = Random.Range(0, 10);
                    Instantiate(enemies[2], new Vector3(platformPosX, platformPosY + randDist, platformPosZ), enemies[2].transform.rotation);
                }
                    
            }

        }       
    }

    public void SpawnBoss()
    {
        Instantiate(enemies[3], new Vector3(platformPosX, platformPosY + randDist, platformPosZ), enemies[3].transform.rotation);
    }
}

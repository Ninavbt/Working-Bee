using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float startDelay = 2;
    private float spawnInterval = 2f;
    private PlayerController playerControllerScript;
    float timeUntilSpawnRateIncrease = 30;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomFlower", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Spawns trees
    void SpawnRandomObstacle()
    {
        float spawnRangeX = 12;
        float spawnPosY = -5.2f;
        float spawnPosZ = -1.3f;
        int obstacleIndex = Random.Range(0, 3);

        // Stop trees spawning on gameOver
        if (playerControllerScript.gameOver == false)
        {
            // Randomly generate trees and spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX, spawnRangeX * 2), spawnPosY, spawnPosZ);
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos,
            obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }

    // Spawns flowers
    void SpawnRandomFlower()
    {
        float spawnRangeX = 12;
        float spawnRangeY = 4.5f;
        float spawnPosZ = -1.3f;
        int flowerIndex = Random.Range(3, 6);

        // Stop flower spawning on gameOver
        if (playerControllerScript.gameOver == false)
        {
            // Randomly generate flowers and spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX, spawnRangeX * 2), Random.Range(-spawnRangeY, spawnRangeY + 1), spawnPosZ);
            Instantiate(obstaclePrefab[flowerIndex], spawnPos,
            obstaclePrefab[flowerIndex].transform.rotation);
        }
    }

}
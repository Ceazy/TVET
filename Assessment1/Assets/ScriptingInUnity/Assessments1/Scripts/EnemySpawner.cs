using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO; //Enemy Prefab

    float maxSpawnRateInSeconds = 5f;

    // Use this for initialization
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //Spawn Enemies every 30 seconds 
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to spawn enemy 

    void SpawnEnemy()
    {
        //Bottom left of screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Top right of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Instantiate Enemy
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //When to spawn next enemy 
        ScheduleNextEnemySpawn();

    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 1f;
        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    //Increase game difficulty
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");

    }
}

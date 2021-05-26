using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int currentEnemyCount;
    public int maxEnemyCount;
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyCount = 0;
        maxEnemyCount = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            GameObject t_enemy = enemies[Random.Range(0, enemies.Length)];
            Transform t_enemySpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(t_enemy, t_enemySpawnPoint.position, t_enemySpawnPoint.rotation);
            currentEnemyCount++;
        }
    }
}

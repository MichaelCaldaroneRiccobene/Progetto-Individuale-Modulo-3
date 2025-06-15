using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int timeToSpawn = 10;
    [SerializeField] int enemyToSpawn = 2;
    [SerializeField] Transform upR, upL, downR, downL;

    private GameManager gameManager;
    private int arenaLarge;
    private Vector3[] spawnPoints;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        arenaLarge = gameManager.ArenaLarge;

        SpawnPointsEnemy();
        StartCoroutine(SpawnEnemys());
    }

    private void SpawnPointsEnemy()
    {
        upR.position = new Vector3(arenaLarge, arenaLarge, 0);
        upL.position = new Vector3(-arenaLarge, arenaLarge, 0);
        downR.position = new Vector3(arenaLarge, -arenaLarge, 0);
        downL.position = new Vector3(-arenaLarge, -arenaLarge, 0);

        spawnPoints = new[] { upR.transform.position, upL.transform.position, downR.transform.position, downL.transform.position };
    }

    IEnumerator SpawnEnemys()
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            int n = Random.Range(0,spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[n], Quaternion.identity, transform);
        }

        gameManager.LevelWordl();
        enemyToSpawn++;
        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine(SpawnEnemys());
    }
}

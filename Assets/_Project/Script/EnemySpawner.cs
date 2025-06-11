using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int timeToSpawn = 10;
    [SerializeField] int enemyToSpawn = 2;
    [SerializeField] int arenaLarge = 49;
    [SerializeField] int rangeA = 5;
    [SerializeField] int rangeB = 12;

    private PlayerController playerController;
    private GameManager gameManager;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        gameManager = FindAnyObjectByType<GameManager>();

        StartCoroutine(SpawnEnemys());
    }

    IEnumerator SpawnEnemys()
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            float spawnX;
            float spawnY;
            if (Random.Range(0,10) >= 5)
            {
                spawnX = playerController.transform.position.x + Random.Range(-rangeA, -rangeB);
                spawnY = playerController.transform.position.y + Random.Range(-rangeA, -rangeB);
            }
            else
            {
                spawnX = playerController.transform.position.x + Random.Range(rangeA, rangeB);
                spawnY = playerController.transform.position.y + Random.Range(rangeA, rangeB);
            }

            spawnX = Mathf.Clamp(spawnX, -arenaLarge, arenaLarge);
            spawnY = Mathf.Clamp(spawnY, -arenaLarge, arenaLarge);

            Vector2 spawnPoint = new Vector2(spawnX, spawnY);   
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity,transform);
        }
        gameManager.LevelWordl();
        enemyToSpawn++;
        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine(SpawnEnemys());
    }
}

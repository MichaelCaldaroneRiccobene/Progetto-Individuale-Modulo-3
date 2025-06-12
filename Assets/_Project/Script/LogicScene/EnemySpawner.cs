using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int timeToSpawn = 10;
    [SerializeField] int enemyToSpawn = 2;
    [SerializeField] int rangeA = 15;
    [SerializeField] int rangeB = 30;
    [SerializeField] int arenaLarge = 49;

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
            gameManager.SpawnObjectClosePlayer(playerController,rangeA,rangeB,arenaLarge,enemyPrefab,transform);
        }

        gameManager.LevelWordl();
        enemyToSpawn++;
        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine(SpawnEnemys());
    }
}

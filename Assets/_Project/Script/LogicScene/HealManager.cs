using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealManager : MonoBehaviour
{
    [SerializeField] GameObject healPrefab;
    [SerializeField] int timeToSpawn = 15;
    [SerializeField] int rangeA = 15;
    [SerializeField] int rangeB = 30;

    private PlayerController playerController;
    private GameManager gameManager;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(SpawnHealsUp());
    }

    IEnumerator SpawnHealsUp()
    {
        gameManager.SpawnObjectClosePlayer(playerController, rangeA, rangeB, healPrefab,transform);

        timeToSpawn++;

        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine(SpawnHealsUp());
    }
}

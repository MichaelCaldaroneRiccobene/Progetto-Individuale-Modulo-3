using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealManager : MonoBehaviour
{
    [SerializeField] GameObject healPrefab;
    [SerializeField] int timeToSpawn = 15;
    [SerializeField] int rangeA = 15;
    [SerializeField] int rangeB = 30;
    [SerializeField] int arenaLarge = 49;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();

        StartCoroutine(SpawnHealsUp());
    }

    IEnumerator SpawnHealsUp()
    {
         float spawnX;
         float spawnY;
         if (Random.Range(0, 10) >= 5)
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
        Instantiate(healPrefab, spawnPoint, Quaternion.identity, transform);
        timeToSpawn++;

        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine(SpawnHealsUp());
    }
}

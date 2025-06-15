using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int arenaLarge = 18;
    public int ArenaLarge => arenaLarge;

    private int enemyDie;
    private int level;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void AddEnemyDie()
    {
        enemyDie++;
        Debug.Log("Enemy Kills " + enemyDie);
    }
    public void LevelWordl()
    {
        level++;
        Debug.Log("//// New Level World " + level + " ////");
    }

    public void SpawnObjectClosePlayer(PlayerController pc,float rangeA,float rangeB,GameObject spawnPrefab,Transform transform)
    {
        float spawnX;
        float spawnY;

        int factorRangeA = Random.Range(0, 2) == 0 ? 1 : -1;
        int factorRangeB = Random.Range(0, 2) == 0 ? 1 : -1;

        rangeA *= factorRangeA; rangeB *= factorRangeB;

        spawnX = pc.transform.position.x + Random.Range(rangeA, rangeB);
        spawnY = pc.transform.position.y + Random.Range(rangeA, rangeB);

        spawnX = Mathf.Clamp(spawnX, -arenaLarge, arenaLarge);
        spawnY = Mathf.Clamp(spawnY, -arenaLarge, arenaLarge);

        Vector2 spawnPoint = new Vector2(spawnX, spawnY);
        Instantiate(spawnPrefab, spawnPoint, Quaternion.identity, transform);
    }
}

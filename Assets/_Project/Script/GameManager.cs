using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private EnemyController enemyController;
    private EnemySpawner enemySpawner;
    private Gun gun;

    private void Start()
    {
        StartCoroutine(FindEnemy());
    }

    private void Update()
    {
        ShootEnemy();
    }

    private void ShootEnemy()
    {
        if(gun == null) {FindGun();return; }

        if (enemyController != null)
        {
            Vector2 dir = enemyController.transform.position - transform.position;
            GameFormula.CalculateDirection(dir);

            if (dir.magnitude < 15) gun.TryToShoot(dir);
        }
    }
    private void FindGun()
    {
       gun = GetComponentInChildren<Gun>();
    }
    private IEnumerator FindEnemy()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();

        float minDist = float.PositiveInfinity;

        for (int i = 0; i < enemySpawner.transform.childCount; i++)
        {
            Transform enemyTransform = enemySpawner.transform.GetChild(i);

            EnemyController enemy = enemyTransform.GetComponent<EnemyController>();
            if (enemy == null) continue;

            float distance = Vector2.Distance(transform.position, enemyTransform.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemyController = enemy;
            }
        }
        yield return new WaitForSeconds(1);

        StartCoroutine(FindEnemy());
    }
}

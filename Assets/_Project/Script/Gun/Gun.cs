using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPreFab;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] int gunRange = 10;

    private float lastShootTimer = 0f;
    private EnemyController enemyController;
    private EnemySpawner enemySpawner;
    private GunAnimation gunAnimation;

    private void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        gunAnimation = GetComponent<GunAnimation>();

        if(enemySpawner != null) StartCoroutine(FindEnemy());
    }
    private void Update()
    {
        ShootEnemy();
    }
    public void Shoot(Vector2 dir)
    {
        lastShootTimer  = Time.time;
        Vector2 spawnBullet = transform.position;

        gunAnimation.AnimationGunShoot();
        gunAnimation.GunFireRate = fireRate;

        Bullet bullet = Instantiate(bulletPreFab, spawnBullet, Quaternion.identity);
        bullet.BulletPositionDirection(dir);
    }

    public void TryToShoot(Vector2 dir)
    {
        bool canShoot = Time.time - lastShootTimer >= fireRate;
        if(!canShoot) return;

        Shoot(dir);
    }

    private void ShootEnemy()
    {
        if (enemyController != null)
        {
            Vector2 direction = enemyController.transform.position - transform.position;
            if (direction.sqrMagnitude > 1) direction /= Mathf.Sqrt(direction.sqrMagnitude);

            if (direction.magnitude < gunRange) TryToShoot(direction);
        }
    }

    private IEnumerator FindEnemy()
    {
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

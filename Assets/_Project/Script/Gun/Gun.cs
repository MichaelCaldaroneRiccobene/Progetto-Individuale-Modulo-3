using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Bullet bulletPreFab;
    [SerializeField] protected float fireRate = 0.5f;
    [SerializeField] protected int gunRange = 10;
    [SerializeField] protected int damage = 4;

    protected float lastShootTimer = 0f;
    protected EnemyController enemyController;
    protected EnemySpawner enemySpawner;
    protected GunAnimation gunAnimation;

    public virtual void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        gunAnimation = GetComponent<GunAnimation>();

        if(enemySpawner != null) StartCoroutine(FindEnemy());
    }
    public virtual void Update()
    {
        ShootEnemy();
    }
    public virtual void Shoot(Vector2 dir)
    {
        lastShootTimer  = Time.time;
        Vector2 spawnBullet = transform.position;

        gunAnimation.AnimationGunShoot();
        gunAnimation.GunFireRate = fireRate;

        Bullet bullet = Instantiate(bulletPreFab, spawnBullet, Quaternion.identity);
        bullet.BulletPositionDirection(dir);
        bullet.Damage = damage;
    }

    public virtual void TryToShoot(Vector2 dir)
    {
        bool canShoot = Time.time - lastShootTimer >= fireRate;
        if(!canShoot) return;

        Shoot(dir);
    }

    public virtual void ShootEnemy()
    {
        if (enemyController != null)
        {
            Vector2 direction = enemyController.transform.position - transform.position;
            Vector2 distance = direction;

            if (direction.sqrMagnitude > 1) direction /= Mathf.Sqrt(direction.sqrMagnitude);
            if (distance.magnitude < gunRange) TryToShoot(direction);
        }
    }

    public virtual IEnumerator FindEnemy()
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

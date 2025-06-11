using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPreFab;
    [SerializeField] float fireRate = 0.5f;

    private float lastShootTimer = 0f;

    public void Shoot(Vector2 dir)
    {
        lastShootTimer  = Time.time;
        Vector2 spawnBullet = transform.position;

        Bullet bullet = Instantiate(bulletPreFab, spawnBullet, Quaternion.identity);
        bullet.BulletPositionDirection(dir);
    }

    public void TryToShoot(Vector2 dir)
    {
        bool canShoot = Time.time - lastShootTimer >= fireRate;
        if(!canShoot) return;

        Shoot(dir);
    }
}

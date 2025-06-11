using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 3;
    [SerializeField] private GameObject sfxImpact;

    private Rigidbody2D rb;
    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    public void BulletPositionDirection(Vector2 dir)
    {
        rb = GetComponent<Rigidbody2D>();

        GameFormula.CalculateDirection(dir);
        rb.velocity = dir * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController life = collision.collider.GetComponent<LifeController>();
        if (life != null) life.AddHp(-damage);

        if (sfxImpact != null) Instantiate(sfxImpact, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}

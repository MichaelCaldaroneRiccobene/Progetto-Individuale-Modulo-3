using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 3;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    public void BulletPositionDirection(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController life = collision.collider.GetComponent<LifeController>();
        if (life != null) life.AddHp(-damage);

        Destroy(gameObject);
    }
}

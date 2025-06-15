using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int damage = 5;

    private Move2D move2D;
    private LifeController lifeController;
    private PlayerController playerController;
    private GameManager gameManager;

    private void Start()
    {
        move2D = GetComponent<Move2D>();
        lifeController= GetComponent<LifeController>();

        playerController = FindFirstObjectByType<PlayerController>();
        gameManager = FindAnyObjectByType<GameManager>();

        move2D.Speed = Random.Range(1, 4);
        if (target == null) target = playerController.transform;
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.transform.position - transform.position);
        move2D.UpdateMovement(direction);

        EnemyDead();
    }

    private void EnemyDead()
    {
        if (lifeController.isDead())
        {
            gameManager.AddEnemyDie();

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController controller = collision.collider.GetComponent<PlayerController>();
        if(controller != null)
        {
            LifeController life = controller.GetComponent<LifeController>();
            if (life != null) life.AddHp(-damage);

            lifeController.AddHp(-life.Hp);
        }
    }
}

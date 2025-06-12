using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] GameObject itemPreFab;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteRenderer iteamSpriteRenderer = itemPreFab.GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = iteamSpriteRenderer.sprite;
        spriteRenderer.color = iteamSpriteRenderer.color;

        transform.localScale = iteamSpriteRenderer.transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if(controller != null)
        {
            Vector2 spawnPos = controller.transform.position + (Vector3.right * 0.5f);
            Instantiate(itemPreFab, spawnPos,Quaternion.identity, controller.transform);

            Destroy(gameObject);
        }
    }
}

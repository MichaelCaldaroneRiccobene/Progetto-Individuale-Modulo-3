using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Vector2 Direction {  get; private set; }
    [SerializeField] private float speed = 5f;
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Max(1,value);
    }

    private Rigidbody2D rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>(); 
    }

    public void UpdateMovement(Vector2 direction) => Direction = GameFormula.CalculateDirection(direction);
    private void FixedUpdate()
    {
        if(Direction != Vector2.zero) rb.MovePosition(rb.position + Direction * (Speed * Time.fixedDeltaTime));
    }
}


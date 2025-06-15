using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int hp = 20;
    [SerializeField] private int maxHp = 20;

    private EntityAnimation entityAnimation;

    private void Start()
    {
        entityAnimation = GetComponent<EntityAnimation>();
    }

    public int Hp
    {
        get => hp;
        set => hp = Mathf.Clamp(value, 0, maxHp);
    }

    public int MaxHp
    {
        get => maxHp;
        set => Mathf.Max(1, maxHp);
    }

    public void AddHp(int amount)
    {
        float currentHP = hp;
        Hp += amount;

        if(currentHP > hp) GetDamage();
    }

    private void GetDamage()
    {
        if(entityAnimation != null) entityAnimation.AnimationHit();
    }

    public bool isDead()
    {
        if (hp <= 0) return true;
        else return false;
    }
}

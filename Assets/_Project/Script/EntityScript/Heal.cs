using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int hpToAdd = 10;
    private LifeController lifeController;

    private void Start()
    {
        lifeController = GetComponentInParent<LifeController>();
        lifeController.AddHp(hpToAdd);

        Destroy(gameObject);
    }
}

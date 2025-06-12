using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int hpToAdd = 10;
    [SerializeField] private GameObject sfxHeal;
    private LifeController lifeController;

    private void Start()
    {
        lifeController = GetComponentInParent<LifeController>();

        lifeController.AddHp(hpToAdd);
        if(sfxHeal != null) Instantiate(sfxHeal,transform.position,Quaternion.identity);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    public float GunFireRate;

    private Animator animator;
    private bool isGunShoot;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void AnimationGunShoot()
    {
        if (!isGunShoot) StartCoroutine(GunShoot());
    }

    private IEnumerator GunShoot()
    {
        isGunShoot = true;
        animator.SetBool("Shoot", true);

        yield return new WaitForSeconds(GunFireRate);

        isGunShoot = false;
        animator.SetBool("Shoot", false);
    }
}

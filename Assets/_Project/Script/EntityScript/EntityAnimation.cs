using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimation : MonoBehaviour
{
    private Animator animator;
    private Move2D move2D;

    private bool isHit;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        move2D = GetComponent<Move2D>();    
    }

    private void Update()
    {
        animator.SetFloat("DirectionX", move2D.Direction.x);
        animator.SetFloat("DirectionY", move2D.Direction.y);
    }

    public void AnimationHit()
    {
        if(!isHit) StartCoroutine(AnimHit());
    } 
    
    private IEnumerator AnimHit()
    {
        isHit = true;
        animator.SetBool("Hit", true);

        yield return new WaitForSeconds(1);

        isHit = false;    
        animator.SetBool("Hit", false);
    }
}

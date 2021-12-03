using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : Enemy
{
    Animator animator;
    //private int Hitpoint = 2;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
  
    }
  
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Bullet2(Clone)")
        {
  
            
            animator.Play("GhostDamage");
  
        }
        if ( coll.gameObject.name == "Weapon")
        {
            animator.Play("ghostdamage1");
        }

        if (hitpoint>=1)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDamage3");
        }
  
    }
    protected override void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath1");
        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAmarelo : Enemy
{
    Animator animator;
    //private int Hitpoint = 2;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Bullet2(Clone)")
        {


            animator.Play("bossAmareloDamage1");

        }
        if (coll.gameObject.name == "Weapon")
        {
            animator.Play("bossAmareloDamage");
        }

        if (hitpoint >= 1)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDamage1");
        }

    }
    protected override void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath1");
        Destroy(gameObject);
    }
}

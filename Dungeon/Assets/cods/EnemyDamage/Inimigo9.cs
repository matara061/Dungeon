using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo9 : Enemy
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


            animator.Play("Inimigo9Damage1");

        }
        if (coll.gameObject.name == "Weapon")
        {
            animator.Play("Inimigo9Damage");
        }

        if (hitpoint >= 1)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDamage2");
        }

    }
    protected override void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath3");
        Destroy(gameObject);
    }
}

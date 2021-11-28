using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02 : Enemy
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


            animator.Play("Inimigo02Damage1");

        }
        if (coll.gameObject.name == "Weapon")
        {
            animator.Play("Inimigo02Damage");
        }

        if (hitpoint >= 1)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDamage");
        }

    }
    protected override void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath4");
        Destroy(gameObject);
    }
}

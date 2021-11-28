using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo1 : Enemy
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


            animator.Play("Inimigo1Damage1");

        }
        if (coll.gameObject.name == "Weapon")
        {
            animator.Play("inimigo1Damage");
        }

        if (hitpoint >= 1)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDamage1");
        }

    }
    protected override void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath2");
        Destroy(gameObject);
    }
}

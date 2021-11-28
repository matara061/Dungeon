using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo3 : Enemy
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


            animator.Play("Inimigo3Damage1");

        }
        if (coll.gameObject.name == "Weapon")
        {
            animator.Play("Inimigo3Damage");
        }

        if (hitpoint >= 1)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDamage4");
        }

    }
    protected override void Death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath4");
        Destroy(gameObject);
    }
}

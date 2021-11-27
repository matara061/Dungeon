using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOff : BattleOn
{
    private int health = 2;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
           
            health--;

            if (health == 1)
            {
                //animator.Play("Ponti2");
                //FindObjectOfType<AudioManager>().Play("Bridge");
                Destroy(gameObject);
                animator.Play("Barreira");

            }

        }

        }
    }

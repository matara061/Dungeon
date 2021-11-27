using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOn : Collidable
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            animator.Play("Barreira2");
        }
    }
}

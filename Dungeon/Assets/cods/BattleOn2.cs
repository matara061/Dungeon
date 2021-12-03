using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOn2 : Collidable
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            //FindObjectOfType<AudioManager>().Stop("Soundtrack batlle");
            animator.Play("BloqueioOn4");
        }

    }
}

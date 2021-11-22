using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    Animator animator;
    private int Hitpoint = 2;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Bullet2(Clone)")
        { 
            
            Hitpoint--;
            animator.Play("GhostDamage");

        }

    }
}

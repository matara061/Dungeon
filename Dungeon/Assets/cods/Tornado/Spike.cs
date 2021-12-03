using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Animator animator;
    private int health = 3;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if  (coll.gameObject.name == "Weapon")
            {
            health--;
            if (health <= 2)
            {
                animator.Play("Spike2");
                FindObjectOfType<AudioManager>().Play("Spikes");
            }

        }
    }
}
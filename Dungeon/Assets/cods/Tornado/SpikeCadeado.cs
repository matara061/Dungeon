using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCadeado : MonoBehaviour
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
        if (coll.gameObject.name == "Weapon")
        {
            health--;
            if (health <= 2)
            {
                animator.Play("Spike3");
                FindObjectOfType<AudioManager>().Play("Unlock");
            }

        }
    }
}

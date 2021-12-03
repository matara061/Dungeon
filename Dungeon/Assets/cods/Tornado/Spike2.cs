using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike2 : MonoBehaviour
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
        if (coll.gameObject.tag == "Bullet")
        {
            health--;
            if (health <= 2)
            {
                animator.Play("Barreira 4");
                FindObjectOfType<AudioManager>().Play("StoneOpen");

            }

        }
    }
}

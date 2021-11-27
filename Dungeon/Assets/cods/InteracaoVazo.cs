using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoVazo : MonoBehaviour
{
    Animator animator;
    private int health = 2;


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
            // Destroy(coll.gameObject);
            health--;

            if (health == 1)
            {
                animator.Play("Vazo2");
                FindObjectOfType<AudioManager>().Play("Vaso");
            }
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoAgua : Collidable
{
    Animator animator;
    private int health = 2;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            health--;


            if (health == 1)
            {
                animator.Play("AguaGelo");
                FindObjectOfType<AudioManager>().Play("IceSound");

            }

        }
    }
}

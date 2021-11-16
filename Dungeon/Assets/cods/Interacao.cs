using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : Collidable
{
    Animator animator;
    private int health = 3;

    // Start is called before the first frame update
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
            //animator.Play("Stone2");
                if (health <= 2)
            {
                animator.Play("Stone3");
            }

                if (health <= 1)
            {
                animator.Play("Stone2");
                FindObjectOfType<AudioManager>().Play("Stone Explosion");
            }

                if (health <= 0)
            {

                Destroy(gameObject);
            }
        }
    }
}

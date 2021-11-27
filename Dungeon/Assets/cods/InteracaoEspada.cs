using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoEspada : Collidable
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
            
            health--;
           

           if (health == 1)
            {
                animator.Play("Ponti2");
                FindObjectOfType<AudioManager>().Play("Bridge");

            }
 
        }
    }
}

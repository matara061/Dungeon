using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : Collidable
{
    Animator animator;
    private int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Fighter"))
        {
            Destroy(coll.gameObject);
            health--;
           // animator.Play("CaixaFire1");

            if (health <= 0)
                Destroy(gameObject);
        }
    }
}

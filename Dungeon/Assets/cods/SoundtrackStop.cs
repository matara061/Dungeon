using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackStop : Collidable
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    // Start is called before the first frame update
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //FindObjectOfType<AudioManager>().Stop("Soundtrack batlle");
            animator.Play("Barreira2");
        }
   
    }
}

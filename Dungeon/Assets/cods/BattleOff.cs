using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOff : MonoBehaviour
{
    private int health = 2;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Bullet2(Clone)" || coll.gameObject.name == "Weapon")
        {
            //FindObjectOfType<AudioManager>().Stop("Soundtrack batlle");
            animator.Play("BloqueioOff2");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable // collectable é uma criança de collidable
{
    // logica
    protected bool collected;     // protected significa que ele é privado para todos menos para as suas crinças 

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}

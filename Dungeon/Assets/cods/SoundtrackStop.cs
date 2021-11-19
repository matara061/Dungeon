using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackStop : Collidable
{
    // Start is called before the first frame update
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            FindObjectOfType<AudioManager>().Stop("Soundtrack batlle");

    }
}

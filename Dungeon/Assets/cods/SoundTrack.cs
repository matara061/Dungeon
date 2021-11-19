using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : Collidable
{
    // Start is called before the first frame update
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {


            FindObjectOfType<AudioManager>().Play("Soundtrack batlle");
            Destroy(gameObject);
        }
    }

   // protected virtual void OnCollect()
   // {
   //     collected = true;
   // }
}

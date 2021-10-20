using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable  // chest é uma criança de collectable que é uma criança de collidable
{

    public Sprite emptyChest;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
           // GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 22, Color.yellow, transform.position, Vector3.up * 25, 3.0f);
            Debug.Log("Grant " + pesosAmount + " pesos! ");
        }
    }
}

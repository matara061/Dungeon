using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Weapon     //EnemyHitbox 
{
    public GameObject hitEffect;

    [SerializeField]
    float speed;

    void FixedUpdate() 
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Fighter")) // coll.Tag é o original
        {
            if (coll.name == "Player") // nao precisa ignorar apenas fazer o fire point esta sempre a frente do jogodor, fazer a sprite do jogador seguir o mouse 
                return;

            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            Debug.Log(coll.name);
            coll.SendMessage("ReceiveDamage", dmg);

        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject); // this.

    }



   // private void OnCollisionEnter2D(Collision2D Col)
   // {
   //     GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
   //     Destroy(effect, 1f);
   //     Destroy(gameObject); // this.
   // }
}

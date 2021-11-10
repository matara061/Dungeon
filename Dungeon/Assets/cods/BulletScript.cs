using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Collidable           //Weapon     //EnemyHitbox 
{
    public GameObject hitEffect;

    [SerializeField]
    float speed;

    public Gun gun;

   // public int[] damagePoint = { 1, 2, 3, 4, 5, 6, 7 };
   // public float[] pushForce = { 2.0f, 2.2f, 2.5f, 2.8f, 3f, 3.6f };

    protected override void Start()
    {
        base.Start();
    }

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

                damageAmount = gun.damagePoint[gun.gunLevel], //
                origin = transform.position,
                pushForce = gun.pushForce[gun.gunLevel]
            };
   
            Debug.Log(coll.name);
            coll.SendMessage("ReceiveDamage", dmg);
            

        }
       
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.1f);
        Destroy(gameObject); // this.
        FindObjectOfType<AudioManager>().Play("FireBall Impact");


    }



    //private void OnCollisionEnter2D(Collision2D Col)
    //{
    //     GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //     Destroy(effect, 1f);
    //    Destroy(gameObject); // this.
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : Mover 
{
    public float moveSpeed = 5f;
   // public Rigidbody2D rb;

    public Animator animator;

    private Vector3 mousePosition;

    Vector2 movement;

    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // sprite vira com o mouse
        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed); 
            if (this.transform.position.x > mousePosition.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
                transform.localScale = Vector3.one;

        }

        // Os float's abaixo são parametros para a animação, dessa forma é possivel criar o Blend Tree
        movement.x = x;
        movement.y = y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);



        UpdateMotor(new Vector3(x, y, 0));

        DontDestroyOnLoad(gameObject); // add. problema de mov esta no animator 

    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            TakeDamage();

            //GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);
            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

   // protected override void Death() // arrumar dps
   // {
   //     Destroy(gameObject);
   // }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : Mover //Player
{
    public float moveSpeed = 5f;
   // public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        // Os float's abaixo são parametros para a animação, dessa forma é possivel criar o Blend Tree
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.x = x;
        movement.y = y;

        UpdateMotor(new Vector3(x, y, 0));

        DontDestroyOnLoad(gameObject); // add

    }


    //  private void FixedUpdate()
    //  {
    //      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    //  }
}

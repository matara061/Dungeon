using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;


    // virtual voids: Esses métodos são virtuais e podem ser sobrescritos
    //in child classes
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        // reseta moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // vira a sprite 
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one; // vector.one é abreviação de Vector3(1, 1, 1)
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // faz movimento
        //  transform.Translate(moveDelta * Time.deltaTime);

        // add push vector, if any
        moveDelta += pushDirection;

        // reduz a força de pressão a cada quadro, com base na velocidade de recuperação 
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // certifique-se de que podemos nos mover nessa direção, lançando uma caixa lá primeiro, se a caixa retornar nulo, estamos livres para nos mover 
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make this thing move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make this thing move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}

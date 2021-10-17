using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : EnemyHitbox
{
    public GameObject hitEffect;

    [SerializeField]
    float speed;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D Col)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(this.gameObject);
    }
}

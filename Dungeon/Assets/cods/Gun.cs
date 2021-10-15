using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefabs;

    public float bulletForce = 20f;

  //  Vector3 mousePos = Input.mousePosition;

    [SerializeField]
    float speed;

    void Start()
    {
        animator = GetComponent<Animator>();

        Vector3 mousePos = Input.mousePosition;

        Rigidbody2D rb = bulletPrefabs.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    void FixedUpdate()
    {
        // Faz com que a sprite siga o mouse
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        // matematica vetorial. Pega dois valores vetoriais e subtrai um pelo outro para obter um novo; utilizado para obter uma rotação mais fluida
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, transform.rotation);

        // -- O comentado abaixo é Utilizado para deixar tiro mais rapido e tentar virar a sprite. Bug maroto

        //Rigidbody2D rb = bulletPrefabs.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint * bulletForce, ForceMode2D.Impulse);

        //bullet.transform.position = firePoint.transform.position;
        //bullet.GetComponent<Weapon>().StartShoot(isSpriteLeft);


    }
}

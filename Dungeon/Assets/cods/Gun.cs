using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefabs;
    SpriteRenderer sprite;

    public float bulletForce = 20f;

    // damage struct
    public int[] damagePoint = { 1, 2, 3, 4, 5, 6, 7 };
    public float[] pushForce = { 2.0f, 2.2f, 2.5f, 2.8f, 3f, 3.6f };

    // upgrade
    public int gunLevel = 0;
    private SpriteRenderer spriteRenderer;



    [SerializeField]
    float speed;

    //cooldown
    public float FireRate;
    float nextTimeToFire = 0;

    public BulletScript bullet;

    void Start()
    {
        animator = GetComponent<Animator>();

        Vector3 mousePos = Input.mousePosition;

        sprite = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // talvez de ruim

        Rigidbody2D rb = bulletPrefabs.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1")) // fazer segurar botao para atirar ao invez de apertar toda hora 
        {
           

            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
                
            }
             
        }
        bullet.gunLevel = gunLevel;

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

        if (mousePos.x < screenPoint.x)
        {
            sprite.flipY = true;
        }
        else
        {
            sprite.flipY = false;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("EnergyShoot");

        // -- O comentado abaixo é Utilizado para deixar tiro mais rapido e tentar virar a sprite. Bug maroto

        //Rigidbody2D rb = bulletPrefabs.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint * bulletForce, ForceMode2D.Impulse);

        //bullet.transform.position = firePoint.transform.position;
        //bullet.GetComponent<Weapon>().StartShoot(isSpriteLeft);


    }

    public void UpgradeGun()
    {
        Debug.Log("UPgrad");
        bullet.gunLevel++;
        gunLevel++;
        spriteRenderer.sprite = GameManager.instance.gunSprites[bullet.gunLevel];
        FindObjectOfType<AudioManager>().Play("Level Up");

        // change stats %%
    }

    public void SetGunLevel(int level)
    {
        bullet.gunLevel = level;
        spriteRenderer.sprite = GameManager.instance.gunSprites[bullet.gunLevel];
        FindObjectOfType<AudioManager>().Play("Level Up");
    }
}

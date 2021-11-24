using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : Collidable // : monobehav....
{
	// damage struct
	public int[] damagePoint = {1, 2, 3, 4, 5, 6, 7 };
	public float[] pushForce = { 2.0f, 2.2f, 2.5f, 2.8f, 3f, 3.6f };

	// upgrade
	public int weaponLevel = 0;
	private SpriteRenderer spriteRenderer;

	// Swing
	private Animator anim;
	private float cooldown = 0.5f;
	private float lastSwing;

    private void Awake()
    {
		spriteRenderer = GetComponent<SpriteRenderer>(); // tem outro jeito de fazer se der ruim. 5:31:35
	}

    protected override void Start()
	{
		base.Start();
		spriteRenderer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	protected override void Update()
	{
		base.Update();

		//if (Input.GetKeyDown(KeyCode.Space))
		if (Input.GetButtonDown("Fire1"))
		{
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				Swing();
			}
		}
	}

	protected override void OnCollide(Collider2D coll)
	{
		if (coll.CompareTag("Fighter")) // coll.Tag é o original
		{
			if (coll.name == "Player" ) //|| coll.name == "Bullet")
				return;

			// create a new damage object, then we ll send it to the fighter we ve hit 
			Damage dmg = new Damage
			{
				damageAmount = damagePoint[weaponLevel],
				origin = transform.position,
				pushForce = pushForce[weaponLevel]
			};

			Debug.Log(coll.name);
			coll.SendMessage("ReceiveDamage", dmg);

		}
	}

	private void Swing()
	{
		//Debug.Log("Swing");
		anim.SetTrigger("Swing");
		FindObjectOfType<AudioManager>().Play("Sword5");
	}

	public void UpgradeWeapon()
    {
		Debug.Log("UPgrad");
		FindObjectOfType<AudioManager>().Play("Level Up");
		weaponLevel++;
		spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

		// change stats %%
    }

	public void SetWeaponLevel(int level)
    {
		weaponLevel = level;
		spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : Mover 
{
    public float moveSpeed = 5f;
  
    public Animator animator;

    public Animator anin;

    private Vector3 mousePosition;

    Vector2 movement;

    public CharacterMenu menu;
    public GameManager game;

    public GameObject DeathUi;
    public GameObject player;

    public static PlayerMovement2 instance;

    // verifica se objeto nao esta duplicado, se tiver destruir duplicata
    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


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

        // DontDestroyOnLoad(gameObject);  


    }

    protected override void ReceiveDamage(Damage dmg)
    {
        

        base.ReceiveDamage(dmg);
        FindObjectOfType<AudioManager>().Play("Damage");
        GameManager.instance.OnHitpointChange();
    }

    public void OnLevelUp()
    {
        FindObjectOfType<AudioManager>().Play("Level Up");
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
            OnLevelUp();
        

    }

    

    protected override void Death() 
    {
        FindObjectOfType<AudioManager>().Play("Click");
        DeathUi.SetActive(true);
        player.SetActive(false);
        hitpoint = maxHitpoint;
        game.pesos = game.pesos / 2; // n testado
        Time.timeScale = 0f;
       // SceneManager.LoadScene("Testes");
       // this.transform.position = GameObject.Find("SpawnPoint").transform.position;
       // hitpoint = maxHitpoint;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null) // if (GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(hud);
            Destroy(menu);
            return;
        }

       // PlayerPrefs.DeleteAll(); // delet dps

        instance = this;
       // SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);

    }

    // ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<Sprite> gunSprites;
    public List<int> gunPrices;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // references
    public PlayerMovement2 player; // Player
    public Weapon weapon;
    public RectTransform hitpointBar;
    public GameObject hud;
    public GameObject menu;
    public Gun gun;

    // public FloatingTextManager floatingTextManager;

    // logic
    public int pesos;
    public int experience;

    // Floating Text
   // public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
   // {
   //     floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
   // }

    // Upgrade weapon 
    public bool TryUpgradeWeapon()
    {
        Debug.Log("try up");
        // is the weapon level max ?
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if (pesos >= weaponPrices[weapon.weaponLevel]) 
        {
            Debug.Log("tenho grana");
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    public bool TryUpgradeGun()
    {
        Debug.Log("try up");
        // is the weapon level max ?
        if (gunPrices.Count <= gun.gunLevel)
            return false;

        if (pesos >= gunPrices[gun.gunLevel])
        {
            Debug.Log("tenho grana");
            pesos -= gunPrices[gun.gunLevel];
            gun.UpgradeGun();
            return true;
        }

        return false;
    }

    public void OnHitpointChange() // barra de vida
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        hitpointBar.localScale = new Vector3(ratio, 1, 1);
    }

    // Exp sistema
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while (experience >= add)
        {
            add += xpTable[r];
            r++;

            if (r == xpTable.Count) // level max
                return r;
        }

        return r;
    }

    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;

        while(r < level)
        {
            xp += xpTable[r];
            r++;
        }

        return xp;
    }

    public void GrantXp(int xp)
    {
        int currLevel = GetCurrentLevel();
        experience += xp;
        if (currLevel < GetCurrentLevel())
            OnLevelUp();
    }

    public void OnLevelUp()
    {
        Debug.Log("Level up");
        player.OnLevelUp();
        OnHitpointChange(); // n testado
    }

    // salva status
    public void SaveState() // Scene s, LoadSceneMode mode
    {

         string s = "";
         s += "0" + "|";
         s += pesos.ToString() + "|";
         s += experience.ToString() + "|";
         s += weapon.weaponLevel.ToString();
        
         PlayerPrefs.SetString("SaveState", s);


        Debug.Log("SaveState");
    }


    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {

        SceneManager.sceneLoaded += LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // change player skin
        pesos = int.Parse(data[1]);

        // Exp
        experience = int.Parse(data[2]);
        if (GetCurrentLevel() != 1)
             player.SetLevel(GetCurrentLevel());

        // muda o nivel da weapon 
        weapon.SetWeaponLevel(int.Parse(data[3]));

        //player.transform.position = GameObject.Find("SpawnPoint").transform.position;

        Debug.Log("LoadState");
    }

    public void SaveGame()
    {   
            SaveSystem.SavePlayer(this);
            Debug.Log("savegame");
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        experience = data.level;
        player.hitpoint = data.health;
        pesos = data.pesos;
        weapon.weaponLevel = data.weapon;

        player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]); // n sei se da certo.

    }


}

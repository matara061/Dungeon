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
            return;
        }

        PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    // ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // references
    public PlayerMovement2 player; // Player

    public Weapon weapon;

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
        // is the weapon level max ?
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if (pesos >= weaponPrices[weapon.weaponLevel])
        {
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    // salva status
    public void SaveState() // Scene s, LoadSceneMode mode
    {

         string s = "";
         s += "0" + "|";
         s += pesos.ToString() + "|";
         s += experience.ToString() + "|";
         s += "0";
        
        // PlayerPrefs.SetString("SaveState");


        Debug.Log("SaveState");
    }

    // public void LoadState()
    // {
    //     if (!PlayerPrefs.HasKey("SaveState"))
    //         return;
    //
    //     string[] data = PlayerPrefs.GetString("SaveState").Split('|');
    //
    //     // change player skin
    //     pesos = int.Parse(data[1]);
    //     experience = int.Parse(data[2]);
    //     // change the weapon level
    //
    //     Debug.Log("LoadState");
    // }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
       // SceneManager.sceneLoaded -= LoadState;
        Debug.Log("LoadState");
    }

}

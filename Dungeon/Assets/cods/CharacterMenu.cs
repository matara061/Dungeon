using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // text fields
    public Text levelText, hitpointText, pesosText, upgradeCostText, upgradeCostTextW, xpText;

    // logic
    private int currentCharacterSeletion = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public Image gunSprite;
    public RectTransform xpBar;

    public Animator anin;

    public GameObject player;
    public GameObject Weapon;
    public GameObject Gun;
    public GameObject fire;

    // Character selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSeletion++;

            // if we went too far away
            if (currentCharacterSeletion == GameManager.instance.playerSprites.Count)
                currentCharacterSeletion = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSeletion--;

            if (currentCharacterSeletion < 0)
                currentCharacterSeletion = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();

        }
    }

    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSeletion];
    }

    // weapon upgrade
    public void OnUpgradeClick()
    {
        //FindObjectOfType<AudioManager>().Play("Level Up");
        Debug.Log("uppppppp");
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    // gun upgrade
    public void OnUpgradeClickW()
    {
      //  FindObjectOfType<AudioManager>().Play("Level Up");
        Debug.Log("uppppppp");
        if (GameManager.instance.TryUpgradeGun())
            UpdateMenu();
    }

    // update character information 
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        // gun
        gunSprite.sprite = GameManager.instance.gunSprites[GameManager.instance.bullet.gunLevel];
        if (GameManager.instance.bullet.gunLevel == GameManager.instance.gunPrices.Count)
            upgradeCostTextW.text = "MAX";
        else
            upgradeCostTextW.text = GameManager.instance.gunPrices[GameManager.instance.bullet.gunLevel].ToString();

        // Meta
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();

        // XP bar

        int currLevel = GameManager.instance.GetCurrentLevel();
        if (GameManager.instance.GetCurrentLevel() == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + " total experience points"; // mostra total xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currLevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }

       // xpText.text = "NOT IMPLEMENTED";
       // xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
    public void OpenMenu()
    {
        
            UpdateMenu();
            anin.SetTrigger("show");
            player.SetActive(false);
        Menu = true;
            
       
    }

    public void closeMenu()
    {
        UpdateMenu();
        anin.SetTrigger("hide");
        player.SetActive(true);
        Menu = false;
    }

    public static bool Menu = false;
    private void Update()
    {
        if (Input.GetKeyDown("i") || Input.GetKeyDown(KeyCode.Escape))
        {
            if(Menu)
            {
                closeMenu();
            }
            else
            {
                OpenMenu();
            }
        }

        if (Input.GetKeyDown("1"))
        {
            Gun.SetActive(false);
            fire.SetActive(false);
            Weapon.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            Weapon.SetActive(false);
            Gun.SetActive(true);
            fire.SetActive(true);
        }

        if(Weapon.activeSelf) // gambiarra
        {
            Gun.SetActive(false);
            fire.SetActive(false);
        }else if(Gun.activeSelf)
            Weapon.SetActive(false);
    }
}

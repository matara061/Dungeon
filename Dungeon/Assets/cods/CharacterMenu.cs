using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // text fields
    public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

    // logic
    private int currentCharacterSeletion = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

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
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    // update character information 
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[0];
        upgradeCostText.text = "NOT IMPLEMENTED";

        // Meta
        levelText.text = "NOT IMPLEMENTED";
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();

        // XP bar
        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}

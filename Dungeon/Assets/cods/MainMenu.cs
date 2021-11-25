using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Guild");
    }

    public void Tutorial()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("quit");
        Application.Quit();
    }

    GameManager game;
    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        // carregar ultima sena, sprites da arma atual

        SceneManager.LoadScene(data.scene); // esta dando conflito com o spaw point
        game.experience = data.level;
        game.player.hitpoint = data.health;
        game.pesos = data.pesos;
        game.weapon.weaponLevel = data.weapon;

        game.player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }

    public void Creditos()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("credits");
    }
}

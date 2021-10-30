using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Testes");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}

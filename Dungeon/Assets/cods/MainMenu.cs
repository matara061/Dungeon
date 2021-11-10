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
}

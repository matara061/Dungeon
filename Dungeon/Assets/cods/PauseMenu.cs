using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // variavel que verifica se o jogo está pausado ou não
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<AudioManager>().Play("Click");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        // Realiza o processo abaixo caso o botão de pause seja ativado.
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        // é possivel inserir o save game ou uma tela de carregamento nessa função quando tiver uma
        Time.timeScale = 1f;
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        // é possivel configurar um LoadScene nessa função. Assim o jogo atual é encerrado e volta para a tela inicial
        Application.Quit();
        Debug.Log("Saindo do jogo");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarNivel : MonoBehaviour
{
    public Animator transition;

    // Update is called once per frame
   // private void OnCollide(Collider2D coll)
   // {
   //     if (coll.name == "Player")
   //     {
   //         LoadNextLevel();
   //     }
   // }

    public void LoadNextLevel()
    {
        StartCoroutine (LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // atrasa a cena para carregar corretamente.
    IEnumerator LoadLevel( int levelIndex )
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);

    }
}

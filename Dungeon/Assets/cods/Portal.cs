using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;

   // public PlayerMovement2 player;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            // teleporta player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            //player.transform.position = new Vector3(0, 0, 0);
        }
    }
}

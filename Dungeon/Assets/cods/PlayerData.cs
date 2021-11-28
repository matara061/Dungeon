using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class PlayerData 
{
    public int level, pesos, health, weapon, gun;

    public float[] position;

    public string scene;

    public PlayerData (GameManager game)
    {
        level = game.experience;
        health = game.player.hitpoint;
        pesos = game.pesos;
        weapon = game.weapon.weaponLevel;
        gun = game.gun.gunLevel;
        scene = SceneManager.GetActiveScene().name;

        position = new float[3];
        position[0] = game.player.transform.position.x;
        position[1] = game.player.transform.position.y;
        position[2] = game.player.transform.position.z;

    }
    

}

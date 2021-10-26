using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public Transform cameraTransform;
    public KeyCode pickupKey = KeyCode.E;
    public KeyCode dropKey = KeyCode.G;
    string weaponTag = "Weapon";

    public List<GameObject> weapons;
    public int maxWeapons = 2;

    // esta variável representa a arma que você carrega em suas mãos 
    public GameObject currentWeapon;

    // esta variável representa sua mão que você definiu como parente de sua arma atual
    public Transform hand;

     // Insira um objeto de jogo que você soltar dentro do objeto de jogo do seu jogador e posicione-o onde deseja soltar os itens
     // para evitar a queda de itens dentro do seu player
    public Transform dropPoint;

    

    void Update()
    {

        // SELECT WEAPONS
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }

        // PICKUP WEAPONS
        RaycastHit hit;
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        // se acertar algo
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit + " algo");
            if (hit.transform.CompareTag(weaponTag) && Input.GetKeyDown(pickupKey))//&& weapons.Count < maxWeapons)
            {
                Debug.Log(hit + " pick");
                // salva a weapon               
                weapons.Add(hit.collider.gameObject);
                
                //esconde a arma porque agora está em nosso 'inventário'
                hit.collider.gameObject.SetActive(false);

                
                  // now we can positioning the weapon at many other places.
                  // but for this demonstration where we just want to show a weapon
                  // in our hand at some point we do it now.
                  hit.transform.parent = hand;
                  hit.transform.position = Vector3.zero;

            }
        }

        // DROP WEAPONS
        //  recurso no qual deseja largar a arma que carrega na mão
        if (Input.GetKeyDown(dropKey) && currentWeapon != null)
        {
            Debug.Log(hit + " droup");
            // Primeiro, certifique-se de remover nossa mão como parente da weapon
            currentWeapon.transform.parent = null;

            // mover weapon para droup position
            currentWeapon.transform.position = dropPoint.position;

            // remover do inventario            
            var weaponInstanceId = currentWeapon.GetInstanceID();
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].GetInstanceID() == weaponInstanceId)
                {
                    weapons.RemoveAt(i);
                    break;
                }
            }

            // remover da mao 
            currentWeapon = null;
        }
    }

    void SelectWeapon(int index)
    {

        // Certifique-se de que temos uma arma no 'slot' desejado
        if (weapons.Count > index && weapons[index] != null)
        {

            // Verifique se já está carregando uma arma
            if (currentWeapon != null)
            {
                // esconde weapon               
                currentWeapon.gameObject.SetActive(false);
            }

            // Add nova arma
            currentWeapon = weapons[index];

            // mostra nova arma
            currentWeapon.SetActive(true);
        }
    }

}

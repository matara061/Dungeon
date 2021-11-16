using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoPlayer : MonoBehaviour
{
    public bool Interacao {get; set; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interage"))
        {
            Interacao = true;
        }
        else
        {
            Interacao = false;
        }
    }
}

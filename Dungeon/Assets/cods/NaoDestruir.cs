using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoDestruir : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

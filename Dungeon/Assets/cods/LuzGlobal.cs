using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LuzGlobal : MonoBehaviour
{
    Light2D luz;
    float sentido = 1;
    void Start()
    {
        luz = GetComponent<Light2D>();
    }

    void Update()
    {
        luz.intensity += 0.1f *sentido* Time.deltaTime;
        if (luz.intensity == 0)
        {
            sentido = 1;
            luz.color = Color.blue;
        }
        else if (luz.intensity <= 1)
        {
            sentido = -1;
        }
    }
}

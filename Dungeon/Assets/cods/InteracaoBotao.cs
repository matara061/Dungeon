using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteracaoBotao : MonoBehaviour
{
    [SerializeField]
    private InteracaoPlayer jogadorInterage;

    [SerializeField]
    private UnityEvent botaoApertado;

    public bool ExecutarInteracao;

    // Update is called once per frame
    void Update()
    {
        if (ExecutarInteracao)
        {
            if(jogadorInterage.Interacao == true)
            {
                botaoApertado.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ExecutarInteracao = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExecutarInteracao = false;
    }
}

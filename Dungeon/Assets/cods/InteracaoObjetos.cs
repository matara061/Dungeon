using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] // que poha é essa? verificar posteriormente, ajuda a não dar erro no animator
public class InteracaoObjetos : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Abre()
    {
        animator.Play("CaixaFire");
    }
}

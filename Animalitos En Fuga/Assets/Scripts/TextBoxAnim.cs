using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxAnim : MonoBehaviour
{
    Animator anim;
    bool isHiding;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void PlayAnimationButton()
    {
        if(isHiding)
        {
            anim.Play("Mostrar");
        } else {
            anim.Play("Esconder");
        }
        // Cambiamos el estado.
        isHiding = !isHiding;
    }
}

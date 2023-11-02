using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public VFXManager.VFXName effectName;
    public string textoDialogo;
    TextMeshProUGUI textBox;


    void Start()
    {
        textBox = GameManager.Instance.textBox;
    }

    public void ButtonClicked()
    {
        // Sonido de NPC
        //VFXManager.Instance.PlayVFX(effectName);
        // Dialogo NPC
        textBox.text = textoDialogo;
    }

}

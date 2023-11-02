using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public string texto;
    public string animalLinkeado;
    TextMeshProUGUI textBox;

    void Start()
    {
        textBox = GameManager.Instance.textBox;
    }

    public void ButtonClicked()
    {
        // Cambiamos el texto de la caja
        textBox.text = texto;
        // Seteamos el item a true
        GameManager.Instance.SetPlayerPref(animalLinkeado, 1);
        // Reproducimos sonidito.
        VFXManager.Instance.PlayVFX(VFXManager.VFXName.GET_ITEM);
        // Apagamos el item
        gameObject.SetActive(false);
    }
}

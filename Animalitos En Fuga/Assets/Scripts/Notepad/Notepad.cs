using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notepad : MonoBehaviour
{
    // Lista de referencias de los textos
    public List<TextMeshProUGUI> references = new List<TextMeshProUGUI>();
    // Lista de animalitos para checkear su estado de activo. Tienen que estar en el mismo orden que las referencias de arriba.
    public List<GameObject> animalList = new List<GameObject>();

    void OnEnable()
    {
        CheckearTachado();
    }

    void CheckearTachado()
    {
        int i = 0;
        foreach (GameObject animal in animalList)
        {
            // Si el animal esta activo
            bool result = animal.activeSelf;
            if (!result)
            {
                references[i].fontStyle = FontStyles.Strikethrough;
            }
            i++;
        }
    }
}


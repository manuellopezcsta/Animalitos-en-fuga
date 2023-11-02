using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMochila : MonoBehaviour
{
    [SerializeField] int indexAnimal;

    // Lo linkeamos al boton.
    public void UsarItem()
    {
        Debug.Log(indexAnimal);
        GameManager.Instance.CheckIfItemWorks(indexAnimal);
    }
}

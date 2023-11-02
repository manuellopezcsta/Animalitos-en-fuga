using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Animal : MonoBehaviour
{
    //public string nombreAnimal;
    [SerializeField] GameObject itemQueDesbloquea;
    public VFXManager.VFXName effectName;
    public string textoCorrecto;
    public string textoFaltaItem;
    TextMeshProUGUI textBox;


    void Start()
    {
        textBox = GameManager.Instance.textBox;
    }

    public void ButtonClicked()
    {
        // Hacemos que el animal haga ruido
        VFXManager.Instance.PlayVFX(effectName);
        // Mostramos el texto de pista para el animal
        textBox.text = textoFaltaItem;
    }

    // La pones en el boton y sirven para onda desbloquear otro game object cuando vos quieras.
    // Tambien se puede como recompensa por salvar a algun animal.
    void UnlockItem(GameObject target)
    {
        // Es lo mismo que hacerlo desde el boton , pero con esto lo podes correr desde dentro de un if y hacerlo condicional.
        if (target != null) // Si no queres que el animal desbloquee algo x ejemplo, no lo definis y esto no hace nada.
        {
            Debug.Log("Desbloqueando item: " + target.name);
            target.SetActive(true);
        }
    }

    public void UsedCorrectObject()
    {
        gameObject.SetActive(false);
        VFXManager.Instance.PlayVFX(effectName);
        textBox.text = textoCorrecto;
        UnlockItem(itemQueDesbloquea);
    }

    void OnDisable()
    {
        if (GameManager.Instance.animales.All(obj => !obj.activeSelf))
        { 

            // FUnción de victoria del gameManager.
            GameManager.Instance.Ganar();
        };

    }

}

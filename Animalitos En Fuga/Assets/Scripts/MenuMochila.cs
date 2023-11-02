using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMochila : MonoBehaviour
{
    // Imagenes de los items correctos.
    public List<Sprite> itemsPictures = new List<Sprite>();
    // Referencia a los lugares donde van las imagenes
    public List<Image> references = new List<Image>();

    public string[] AnimalNames;
    void OnEnable()
    {
        // Rellenamos la mochila con los items correctos al abrirla.
        LLenarMochila();
    }
    // Start is called before the first frame update
    void LLenarMochila()
    {
        int i = 0;
        foreach(string animal in AnimalNames)
        {

            bool result = GameManager.Instance.GetPlayerPref(animal);
            if(result)
            {
                references[i].sprite = itemsPictures[i];
                // Accedemos al boton  y si tenemos el item lo hacemos accesible.
                references[i].gameObject.GetComponent<Button>().interactable = true;
            }
            i++;
        }
    }

}

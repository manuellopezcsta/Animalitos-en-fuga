using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textBox;
    public static GameManager Instance { get; private set; }

    // Lista de referencias a los animales.
    [SerializeField] public List<GameObject> animales = new List<GameObject>();
    [SerializeField] GameObject menuMochila;
    [SerializeField] string incorrectUseText;
    [SerializeField] GameObject panelVictoria;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        // Limpiamos los player Prefs para que el juego corra bien.
        PlayerPrefs.DeleteAll();
    }

    public void SetPlayerPref(string animal, int valor)
    {
        // No existen los bool en player pref asi que usar 0 o 1...
        PlayerPrefs.SetInt(animal, valor);
    }

    // Checkea si tenes el item para el animal, no el animal en si.
    public bool GetPlayerPref(string animal)
    {
        int result = 999;
        if(PlayerPrefs.HasKey(animal))
        {
            result = PlayerPrefs.GetInt(animal);
        }
        else {
            result = 0; // False
        }

        switch(result)
        {
            case 0:
                return false;
            case 1:
                return true;
            default:
                Debug.Log("ERROR MIRAR GAME MANAGER");
                return false;
        }
    }

    public void CheckIfItemWorks(int animalIndex)
    {
        //Apagamos la mochila primero
        menuMochila.SetActive(false);
        // Checkeamos si el objeto animal esta activo... 
        bool isObjectActive = animales[animalIndex].activeInHierarchy;
        //Debug.Log("ANIMAL ACTIVO ES " + isObjectActive);
        // Dependiendo del resultado activamos la funcion correcto.
        Debug.Log(animalIndex);
        if(isObjectActive)
        {
            // Ejecutamos el codigo para ese animal.
            animales[animalIndex].GetComponent<Animal>().UsedCorrectObject();
        }
        else
        {
            // Mostramos un error general.
            textBox.text = incorrectUseText;
            VFXManager.Instance.PlayVFX(VFXManager.VFXName.WRONG_ANSWER);
        }
    }
    public void Ganar()
    {
        VFXManager.Instance.PlayVFX(VFXManager.VFXName.WIN);
        panelVictoria.SetActive(true);
        StartCoroutine(ChangeSceneAfterDelay());

    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Creditos"); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void ChangeToSceneNumber(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CloseGame()
    {
        Debug.Log("Se cerro el juego");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Opciones : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1);
            //CargaPreferencias();
        }
        if(!PlayerPrefs.HasKey("dialogueSpeed")){
            PlayerPrefs.SetInt("dialogueSpeed", 0);
        }
        CargaPreferencias();
    }

    public void ChangeVolume () {
        //AudioListener.volume = volumeSlider.value; 
        VFXManager.Instance.mainSong.volume=volumeSlider.value;
        GuardaPreferencias();
    }

    private void CargaPreferencias () {
        volumeSlider.value=PlayerPrefs.GetFloat("musicVolume");
    }

    private void GuardaPreferencias () {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}

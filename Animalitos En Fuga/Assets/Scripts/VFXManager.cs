using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    /// <summary>
    /// Permite reproducir SFX
    /// </summary>

    // El objeto que se va a generar cada vez que se pide un SFX
    public GameObject parlante;
    public AudioSource mainSong;

    [Header("Clips de VFX")]
    public AudioClip hoverSound;
    public AudioClip wrongAnswer;
    public AudioClip getItem;
    public AudioClip mono;
    public AudioClip gallina;
    public AudioClip yaguarete;
    public AudioClip pinguino;
    public AudioClip yacare;
    public AudioClip zorro;
    public AudioClip nandu;
    public AudioClip carpincho;
    public AudioClip ciervo;
    public AudioClip win;

    [Header("Canciones")]
    public AudioClip inGameSong;
    public AudioClip menuSong;
    public AudioClip creditosSong;

    public enum VFXName { // Sonidos que reproduce
        GET_ITEM,
        HOVER,
        MONO,
        GALLINA,
        YAGUARETE,
        PINGUINO,
        YACARE,
        ZORRO,
        NANDU,
        CARPINCHO,
        CIERVO,
        WRONG_ANSWER,
        WIN
        // Agregar sonido al hacer click en la mochila y la libreta?
    }

    public enum MSName {
        MENU,
        IN_GAME,
        CREDITOS        
    }
    
    // Un diccionario que va a contener todos los clips de audio con su respectivos volumenes.
    Dictionary<VFXName, Tuple<AudioClip, float>> clipLibrary = new Dictionary<VFXName, Tuple<AudioClip, float>>();
    Dictionary<MSName, Tuple<AudioClip, float>> mainSongLibrary = new Dictionary<MSName, Tuple<AudioClip, float>>();

    public static VFXManager Instance { get; private set; }
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

        // Llenamos la libreria
        FillSoundLibrary();
        RegulateVolume();
    }

    public void PlayVFX(VFXName sonido){
        // Creamos un parlante
        GameObject efectoSonoro = Instantiate(parlante);
        // Lo colocamos como hijo del VFX Manager, para no spamear la jerarquia.
        efectoSonoro.transform.parent = transform;
        // Le ponemos un nombre para identificarlo
        efectoSonoro.name = "VFX SOUND - " + sonido.ToString();
        // Accedemos a su audioSource y seteamos el clip, el soonido
        AudioSource audioS = efectoSonoro.GetComponent<AudioSource>();
        audioS.clip = clipLibrary[sonido].Item1;
        audioS.volume = clipLibrary[sonido].Item2;
        // Lo reproducimos, y le decimos que se destruya cuando termine.
        audioS.Play();
        Destroy(efectoSonoro, audioS.clip.length); // Destruye el objeto una vez que termine de reproducirse.    
    }

    void FillSoundLibrary(){
        // Usando las keys de los enum, puedo obtener el sonido y el volumen que corresponde.
        clipLibrary.Add(VFXName.GET_ITEM, Tuple.Create(getItem, 1f));
        clipLibrary.Add(VFXName.WRONG_ANSWER, Tuple.Create(wrongAnswer, 1f));
        clipLibrary.Add(VFXName.HOVER, Tuple.Create(hoverSound, 0.6f));
        clipLibrary.Add(VFXName.YAGUARETE, Tuple.Create(yaguarete, 0.6f));
        clipLibrary.Add(VFXName.MONO, Tuple.Create(mono, 0.6f));
        clipLibrary.Add(VFXName.GALLINA, Tuple.Create(gallina, 0.6f));
        clipLibrary.Add(VFXName.PINGUINO, Tuple.Create(pinguino, 0.6f));
        clipLibrary.Add(VFXName.YACARE, Tuple.Create(yacare, 0.6f));
        clipLibrary.Add(VFXName.ZORRO, Tuple.Create(zorro, 0.6f));
        clipLibrary.Add(VFXName.NANDU, Tuple.Create(nandu, 0.6f));
        clipLibrary.Add(VFXName.CARPINCHO, Tuple.Create(carpincho, 0.6f));
        clipLibrary.Add(VFXName.CIERVO, Tuple.Create(ciervo, 0.6f));
        clipLibrary.Add(VFXName.WIN, Tuple.Create(win, 0.6f));

        // Los de main song
        mainSongLibrary.Add(MSName.IN_GAME, Tuple.Create(inGameSong, 1f));
        mainSongLibrary.Add(MSName.MENU, Tuple.Create(menuSong, 1f));
        mainSongLibrary.Add(MSName.CREDITOS, Tuple.Create(creditosSong, 1f));
    }

    // Esta funcion utiliza el Music Player Original.
    public void PlaySong(MSName song){
        if(mainSong.isPlaying)
        {
            mainSong.Stop();
        }
        // Seteamos los valores.
        mainSong.clip = mainSongLibrary[song].Item1;
        mainSong.volume = mainSongLibrary[song].Item2;
        mainSong.Play();
    }

    void RegulateVolume()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            mainSong.volume = PlayerPrefs.GetFloat("musicVolume");
        } else
        {
            PlayerPrefs.SetFloat("musicVolume", 0.150f);
            mainSong.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    // Llamado desde eventos
    public void ButtonHover()
    {
        PlayVFX(VFXName.HOVER);
    }
}

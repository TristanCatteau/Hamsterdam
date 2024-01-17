using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume;    //Gestion du volume

    [Range(0.1f, 2.5f)]
    public float pitch;    //Gestion de la vitesse du morceau

    public AudioSource source; //A Ajouter sur chaque objet étant une source du son (ici le sol)

    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();

        volume = 0.5f;
        pitch = 1f;
    }

    void Start()
    {
        source.clip = sound; //AudioClip récupéré via l'inspector
        source.volume = volume;
        source.pitch = pitch;
        source.loop = true;
        //On associe les valeurs qu'on fixe pour le pitch et le volume au fichier source

        source.Play();
    }

    void Update()
    {

    }

//Pourra servir dans des cas futurs d'utilisations, je laisse ça là pour le moment
    public void PlayandPause()
    {
        if (!source.isPlaying) //Si la source ne joue pas
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }
}

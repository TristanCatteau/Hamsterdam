using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Eggonthefloor : MonoBehaviour
{
    public AudioClip sound;
    [Range(0f, 1f)]
    public float volume; //Gestion du volume
    [Range(0.1f, 2.5f)]
    public float pitch;

    private AudioSource source;

    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
//La source de son est sur l'objet auquel on attache le script (ici la boîte)
        source = GetComponent<AudioSource>();

        volume = 0.5f;
        pitch = 1f;
    }

    void Start()
    {
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Oeuf")
        {
            Debug.Log("Oeuf a terre");
            ScoreManagerOeuf.livesCount -= 1;
            source.Play();
            Destroy(other.gameObject); 
        }
    }

}



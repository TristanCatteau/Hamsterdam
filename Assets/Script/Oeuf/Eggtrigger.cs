using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Eggtriger : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Panier";
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Oeuf")
        {
            Debug.Log("Oeuf dans panier");
            Destroy(other.gameObject); 
            ScoreManagerOeuf.scoreCount += 1;
            source.Play();
            Debug.Log(ScoreManagerOeuf.scoreCount);
        }
    }

}



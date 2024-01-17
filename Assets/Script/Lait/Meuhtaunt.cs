using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meuhtunt : MonoBehaviour
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
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("a"))
        {
            Debug.Log("Meuh !");
            source.Play();
            transform.Rotate(new Vector3(0,180,0));
        } 
    }
}

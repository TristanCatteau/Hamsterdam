using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioClip sound;
    [Range(0f, 1f)]
    public float volume; //Gestion du volume
    [Range(0.1f, 2.5f)]
    public float pitch;
    private AudioSource source;
    public bool playerIsClose;
    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        volume = 0.5f;
        pitch = 1f;
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
        }
    }
}

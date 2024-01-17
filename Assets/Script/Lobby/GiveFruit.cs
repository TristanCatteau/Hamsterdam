using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFruit : MonoBehaviour
{
    public AudioController audioController;
    //PARTIE SON ---------------------------------------------------------
 public AudioClip sound;
[Range(0f, 1f)]
 public float volume; //Gestion du volume
 [Range(0.1f, 2.5f)]
 public float pitch;    
 private AudioSource source;

void Awake()
 {
/*      gameObject.AddComponent<AudioSource>();
     source = GetComponent<AudioSource>();
     volume = 0.5f;
     pitch = 1f; */
 }
    public GameObject Jeton;
    public GameObject Jeton2;
    // Start is called before the first frame update
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "PNJ1";
        /* source.clip = sound;
        source.volume = volume;
        source.pitch = pitch; */
        if(PlayerPrefs.GetInt("LabyFini") == 1)
        {
            Invoke("VictoryScripted", 3);
        }
    }

   public void VictoryScripted()
    {
        //Arrête la musique du lobby
        //audioController.source.Pause();
        //Joue la musique de victoire
        //source.Play(); 
        //Deplacement PNJ
        gameObject.tag = "PNJ1";
        //gameObject.transform.Rotate(0,5,0);
        //Animation reception Jeton
        Jeton.SetActive(true);  
        
        //Attend 2 secondes avant de remettre la scène à la normale          
        Invoke("EndVicScript", 3);
    }

    public void EndVicScript()
    {
        Jeton.SetActive(true);         
        //audioController.source.Play();//On remet la musique du lobby
        //Canvas.SetActive(true);
        Jeton2.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        Jeton.transform.Rotate(0,0,1);
    }

}

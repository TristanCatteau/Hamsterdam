using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerOeuf : MonoBehaviour
{
    //GESTION DU SON ------------------------------------------------------------------------
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
//GESTION DU SON ------------------------------------------------------------------------

    public MouvementJ MJ;
    public ChangeForm RJ;
    public GameObject gameOver;
    public Text scoreText;
    public Text hiScoreText;
    public Text livesText;
    public static int scoreCount;
    public static int hiScoreCount;
    public static int livesCount = 3;
    public bool sonDefaite = false;
    public bool boucle = true;
    public AudioController ost;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HighScore");
        }
        RJ.canRoll = false;
        MJ.miniJeuLaby = true;
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", hiScoreCount);
        }
        if ( livesCount == 0)
        {
            sonDefaite = true;
        }
        if (sonDefaite && boucle)
        {
            ost.source.Stop();
            source.Play();
            boucle = false;
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            MJ.canMove = false;
        }
        scoreText.text = "Score: " + scoreCount;
        hiScoreText.text = "High-Score: " + hiScoreCount;
        livesText.text = "Lives: " + livesCount;
    }
}

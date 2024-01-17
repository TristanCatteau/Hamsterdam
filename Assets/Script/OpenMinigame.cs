using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
using UnityEngine.InputSystem;

public class OpenMinigame : MonoBehaviour
{
//PARTIE SON ---------------------------------------------------------
    public AudioClip sound;
    [Range(0f, 1f)]
    public float volume; //Gestion du volume
    [Range(0.1f, 2.5f)]
    public float pitch;
    private AudioSource source;
//--------------------------------------------------------------------------

    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject noButton;
    public GameObject yesButton;
    public float wordSpeed;
    public bool playerIsClose;
    public MouvementJ joueur;
    public ChangeForm joueurForm;
    public string scene;
    PlayerInput playerInput;
    public GameObject cam;

    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        volume = 0.5f;
        pitch = 1f;
        playerInput = new PlayerInput();
    }
        void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "PNJ1";
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    private void OnEnable() {
        playerInput.Joueur.Parler.performed += DoParler;
        playerInput.Joueur.Parler.Enable();
    }

    private void OnDisable()
    {
        playerInput.Joueur.Parler.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void DoParler(InputAction.CallbackContext obj)
    {
        if(playerIsClose)
        {
            cam.SetActive(false);
            joueur.canMove = false;
            joueurForm.canRoll = false;
            joueur.handleMovement();
            source.Play();
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                if(dialogueText.text == dialogue[index])
                    {
                        noButton.SetActive(true);
                        yesButton.SetActive(true);
                    }
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = string.Empty;
        index = 0;
        dialoguePanel.SetActive(false);
        joueur.canMove = true;
        joueurForm.canRoll = true;
        cam.SetActive(true);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            noButton.SetActive(true);
            yesButton.SetActive(true);
        }
    }

    public void NextLine()
    {
        noButton.SetActive(false);
        yesButton.SetActive(false);
        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text=string.Empty;
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void LoadScene(String scene)
    {
        cam.SetActive(true);
        noButton.SetActive(false);
        yesButton.SetActive(false);
        SceneManager.LoadScene(scene);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}

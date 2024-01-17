using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    public GameObject canvasOption;
    public GameObject canvasTitle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Commande()
    {
        canvasOption.SetActive(true);
        canvasTitle.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Retour()
    {
        canvasTitle.SetActive(true);
        canvasOption.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public MouvementJ MJ;
    public ChangeForm RJ;
    public GameObject affichage;
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
    if(other.tag == "Player")
    {
        PlayerPrefs.SetInt("LabyFini", 1);
        affichage.gameObject.SetActive(true);
        Time.timeScale = 0;
        MJ.canMove = false;
        RJ.canRoll = false;
    }
}
}

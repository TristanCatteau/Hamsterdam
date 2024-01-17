using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 5f;
    [SerializeField] Text countdownText;
    public MouvementJ MJ;
    public ChangeForm RJ;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        RJ.canRoll = false;
        MJ.miniJeuLaby = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1*Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            currentTime =0;
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            MJ.canMove = false;
            RJ.canRoll = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMG4 : MonoBehaviour
{
    public MouvementJ MJ;
    public ChangeForm RJ;
    public Timer T;
    public void RestartLevel()
    {
        Time.timeScale = 1;
        MJ.canMove = true;
        RJ.canRoll = false;
        MJ.miniJeuLaby = false;
        T.currentTime = T.startingTime;
        SceneManager.LoadScene("MiniGame4-Fruit");
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        MJ.canMove = true;
        RJ.canRoll = true;
        MJ.miniJeuLaby = false;
        T.currentTime = T.startingTime;
        SceneManager.LoadScene("Lobby");
    }
}

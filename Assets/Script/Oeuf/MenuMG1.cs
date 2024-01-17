using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMG1 : MonoBehaviour
{
    public MouvementJ MJ;
    public ChangeForm RJ;
    public ScoreManagerOeuf SMO;
    public void RestartLevel()
    {
        Time.timeScale = 1;
        ScoreManagerOeuf.livesCount = 3;
        ScoreManagerOeuf.scoreCount = 0;
        zone.respawnTime = 5.0f;
        MJ.canMove = true;
        SMO.sonDefaite = false;
        SMO.boucle = true;

        SceneManager.LoadScene(1);
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        ScoreManagerOeuf.livesCount = 3;
        ScoreManagerOeuf.scoreCount = 0;
        zone.respawnTime = 5.0f;
        MJ.canMove = true;
        RJ.canRoll = true;
        MJ.miniJeuLaby = false;
        SceneManager.LoadScene(0);
    }
}

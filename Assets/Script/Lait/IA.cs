using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour {

private float speed=10000 ;
public int monAleatoire;
  
void Start()
 {
    StartCoroutine(MyCoroutine());
 }

 void MoveOn()
{
     if (monAleatoire == 1) //La vache ne bouge pas
    {
        transform.Translate(Vector3.zero);
    }

    if (monAleatoire == 2)
    {
        transform.Translate(Vector3.back);
    }

    if (monAleatoire == 3)
    {
        transform.Translate(Vector3.forward);
    }

    if (monAleatoire == 4)
    {
        transform.Translate(Vector3.left);
    }

    if (monAleatoire == 5)
    {
        transform.Translate(Vector3.right);
    }

}

void Update() 
{

}
    
    IEnumerator MyCoroutine()
{
    print("Début de ma coroutine");
    //Choisit une valeur aletoire pour executer un mouvement
    monAleatoire = Random.Range (1, 6);
    Debug.Log(monAleatoire);
    MoveOn();
    yield return new WaitForSeconds(speed);
}




}
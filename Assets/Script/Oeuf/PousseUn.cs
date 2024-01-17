using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PousseUn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Poussin";
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,1) * Time.deltaTime);

        
    }

private void OnTriggerEnter(Collider other)
{
    if(other.tag == "Barriere")
    {
        Debug.Log("Poussin dans barriere");
        Destroy(gameObject); 
    }
}

}



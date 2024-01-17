using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeForm : MonoBehaviour
{
    public GameObject sphere; // Référence au modèle de la sphère
    public GameObject player;
    public GameObject off;
    public bool estActif = true; // Variable pour suivre l'état actuel
    public Rigidbody rbSphere;
    public Rigidbody rbHamster;
    public bool canRoll = true;
    public GameObject cam;
    public CinemachineFreeLook camFree;
    PlayerInput playerInput;

    void Awake()
    {
        sphere.SetActive(false); // Désactivez la sphère au démarrage
        player.SetActive(true);
        //rbSphere = sphere.GetComponent<Rigidbody>(); // référence le composent qui va nous permettre de fixer la velocité de la sphere à 0
        //rbSphere = sphere.GetComponent<Rigidbody>();
        //rbHamster = player.GetComponent<Rigidbody>();
        camFree = cam.GetComponent<CinemachineFreeLook>();
        //playerInput = GetComponent<PlayerInput>();
        playerInput = new PlayerInput();
        //changeAction = playerInput.actions.FindAction("ChangerDeForme");
    }

    void Update()
    {
        // Vous pouvez utiliser n'importe quelle touche ou bouton pour déclencher le changement
        //if (Input.GetKeyDown(KeyCode.Space) && canRoll)
        //{
        //    ChangerDeForme();
        //}
        // if (estActif)
        // {
        //     player.transform.position = player.transform.position;
        // }
        // else
        // {
        //     player.transform.position = sphere.transform.position;
        // }
    }
    private void OnEnable() {
        playerInput.Joueur.ChangerDeForme.performed += DoChangerDeForme;
        playerInput.Joueur.ChangerDeForme.Enable();
    }

    private void OnDisable()
    {
        playerInput.Joueur.ChangerDeForme.Disable();
    }

    void DoChangerDeForme(InputAction.CallbackContext obj)
    {
        if (canRoll)
        {
            Debug.Log("appuiez");
            estActif = !estActif; // Inversez l'état
            // Activez/désactivez le cube et la sphère en fonction de l'état
            if (!estActif)
            {
                sphere.transform.position = new Vector3(player.transform.position.x, 0 , player.transform.position.z);
                sphere.transform.position += new Vector3(0, 1.2f , 0);
                off.SetActive(estActif);
                sphere.SetActive(!estActif);
                camFree.Follow = sphere.transform;
                camFree.LookAt = sphere.transform;
                //camplayer.SetActive(estActif);
                //camSphere.SetActive(!estActif);
                //sphere.SetActive(true);
                //sphere.transform.eulerAngles = new Vector3(0, 0, 0);
                //rbSphere.Sleep();
                //sphere.SetActive(false);
            }else
            {
                player.transform.position = new Vector3(sphere.transform.position.x, 0, sphere.transform.position.z);
                //player.transform.position += new Vector3(0, 0.5f , 0);
                sphere.SetActive(!estActif);
                off.SetActive(estActif);
                camFree.Follow = player.transform;
                camFree.LookAt = player.transform;
                //camplayer.SetActive(estActif);
                //camSphere.SetActive(!estActif);
                //harmature.transform.eulerAngles = new Vector3(-90, -90, 0);
                //harmature.transform.position = rbSphere.transform.position + new Vector3(0, 0.5f, 0);
                rbHamster.transform.position += new Vector3(0, 0.1f, 0);            
                rbSphere.transform.position += new Vector3(0, 0.1f, 0);
                //rbSphere.transform.position = rbSphere.transform.position + new Vector3(0, 0.0f, 0);
            }

            rbSphere.velocity = Vector3.zero;
            rbSphere.angularVelocity = Vector3.zero;
            rbHamster.velocity = Vector3.zero;
            rbHamster.angularVelocity = Vector3.zero;
        }
    }
}

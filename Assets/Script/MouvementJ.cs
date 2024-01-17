using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementJ : MonoBehaviour
{
//GESTION DU SON ------------------------------------------------------------------------
    public AudioClip sound;
    [Range(0f, 1f)]
    public float volume; //Gestion du volume
    [Range(0.1f, 2.5f)]
    public float pitch;

    private AudioSource source;
//////////////////////////////////////////////////////////////////
    Animator animator;
    int isWalkingHash;
    PlayerInput playerInput;
    bool movementPressed;
    InputAction moveAction;
    [SerializeField] float speed = 10;
    public ChangeForm CF;
    public bool canMove;
    public bool miniJeuLaby = false;
    public GameObject Armature;
    // Start is called before the first frame update
    void Awake()
    {
//GESTION DU SON -------------------------------------------------------
        gameObject.AddComponent<AudioSource>();
        //La source de son est sur l'objet auquel on attache le script (ici la boîte)
        source = GetComponent<AudioSource>();
        volume = 0.5f;
        pitch = 1f;
/////////////////////////////////////////////////////////////////////

        canMove = true;
        //playerInput = GetComponent<PlayerInput>();
        playerInput = new PlayerInput();
        animator = GetComponent<Animator>();
        //moveAction = playerInput.FindAction("Mouvement");
        isWalkingHash = Animator.StringToHash("isWalking");
    }

        void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Player";
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    private void OnEnable() {
        moveAction = playerInput.Joueur.Mouvement;
        moveAction.Enable();
    }

    private void OnDisable() {
        moveAction.Disable();
    }

    private void FixedUpdate() {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            if(CF.estActif)
            {            
                if(miniJeuLaby)
                {
                    movePlayer();
                    handleRotation();
                }    
                else
                {
                    MovePlayerRelativeCamera();
                }
            }
            else
            {
                moveRool();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void MovePlayerRelativeCamera()
    {
        UnityEngine.Vector2 direction = moveAction.ReadValue<UnityEngine.Vector2>();
        UnityEngine.Vector3 forward = Camera.main.transform.forward;
        UnityEngine.Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;
        UnityEngine.Vector3 forwardRelativeVerticalInput = direction.x * right * speed * Time.deltaTime;
        UnityEngine.Vector3 rightRelativeVerticalInput = direction.y * forward * speed * Time.deltaTime;
        UnityEngine.Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;
        this.transform.Translate(cameraRelativeMovement, Space.World);
        if (cameraRelativeMovement != UnityEngine.Vector3.zero)
        {
            Armature.transform.forward = cameraRelativeMovement;
        }
        movementPressed = direction.x != 0 || direction.y != 0;
        handleMovement();
    }
    void movePlayer()
    {
        UnityEngine.Vector2 direction = moveAction.ReadValue<UnityEngine.Vector2>();
        movementPressed = direction.x != 0 || direction.y != 0;
        transform.position += new UnityEngine.Vector3(direction.x, 0, direction.y)*Time.deltaTime*speed;
        handleMovement();
    }

    public void handleMovement()
    {
        bool isWalking = animator.GetBool(isWalkingHash);

        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
            source.Play();
        }
        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
            source.Stop();
        }
    }

    public void handleRotation()
    {
        UnityEngine.Vector3 currentPosition = this.transform.position;
        UnityEngine.Vector2 currentMovement = moveAction.ReadValue<UnityEngine.Vector2>();
        UnityEngine.Vector3 newPosition = new UnityEngine.Vector3(currentMovement.x, 0, currentMovement.y);
        UnityEngine.Vector3 positionToLookAt = newPosition + currentPosition;
        Armature.transform.LookAt(positionToLookAt);
    }

    public void moveRool()
    {
        UnityEngine.Vector2 direction = moveAction.ReadValue<UnityEngine.Vector2>();
        UnityEngine.Vector3 forward = Camera.main.transform.forward;
        UnityEngine.Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;
        UnityEngine.Vector3 forwardRelativeVerticalInput = direction.x * right ;
        UnityEngine.Vector3 rightRelativeVerticalInput = direction.y * forward ;
        UnityEngine.Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;
        CF.rbSphere.AddForce(cameraRelativeMovement*500);
    }
}
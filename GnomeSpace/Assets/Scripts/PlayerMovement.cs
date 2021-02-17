using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CameraController camController;
   
    [SerializeField] private GameObject cam;
    //[SerializeField] private GameObject playerGO;

    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Animator playerAnimator;

    public float playerSpeed;
   
    public SpaceGnome_02_InputActions controls;

    [SerializeField] private float jumpSpeed;
    [SerializeField] private Vector3 jumpHeight;
    
    [SerializeField] bool isFallingIdle;
    [SerializeField] public bool isStanding;
    [SerializeField] public bool isSwimming;
    [SerializeField] public bool isWalking;
    [SerializeField] public bool hardFall1;
    [SerializeField] public bool hardFall2;

    public float gravity;

    public bool jumpingAllowed;
    public bool isJumping;

    public Vector3 moveX;
    public Vector3 negMoveX;
    public Vector3 moveY;
    public Vector3 negMoveY;
    
    public Vector3 playerRotation;
   
    //START SINGLETON

    public static PlayerMovement instance;
    public static PlayerMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerMovement>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<PlayerMovement>();
                    singleton.name = "(Singleton) PlayerManager";
                }
            }
            return instance;
        }
    }
    public void Awake()
    {

        instance = this;
        gravity = -9.87f;
        //playerSpeed = 2f;
        controls = new SpaceGnome_02_InputActions();


        controls.Player.MoveX.performed += context => moveX = Vector3.forward; 
        controls.Player.MoveX.canceled += context => moveX = Vector3.zero;
        controls.Player.MoveNegativeX.performed += context => negMoveX = Vector3.back;
        controls.Player.MoveNegativeX.canceled += context => negMoveX = Vector3.zero;
        controls.Player.MoveY.performed += context => moveY = Vector3.right;
        controls.Player.MoveY.canceled += context => moveY = Vector3.zero;
        controls.Player.MoveNegativeY.performed += context => negMoveY = Vector3.left;
        controls.Player.MoveNegativeY.canceled += context => negMoveY = Vector3.zero;
        controls.Player.Jump.performed += context => jumpHeight = Vector2.up;
        controls.Player.Rotate.performed += context => playerRotation = context.ReadValue<Vector2>();
        controls.Player.Rotate.canceled += context => playerRotation = Vector2.zero;
        //controls.Player.Rotate.performed += context => playerRot = context.ReadValue<Vector2>();
        //controls.Player.Rotate.canceled += context => playerRot = Vector2.zero;
        //Rotate Left => Left Bumper
        //Rotate Right => Right Bumper
        controls.Player.RotateLeft.performed += context => RotateLeft();
        controls.Player.RotateRight.performed += context => RotateRight();

      
    }
    public void RotateLeft()
    {
        transform.Rotate(new Vector3(transform.position.x, transform.position.y), Space.Self);
    }
    public void RotateRight()
    {
        transform.Rotate(new Vector3(transform.position.x, -transform.position.y), Space.Self);
    }
    
    private void Update()
    {
        
       

        Vector3 mX = new Vector3(moveX.x, moveX.y, moveX.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(mX, Space.Self);

        Vector3 negMX = new Vector3(negMoveX.x, negMoveX.y, negMoveX.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(negMX, Space.Self);

        Vector3 mY = new Vector3(moveY.x, moveY.y, moveY.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(mY, Space.Self);

        Vector3 negMY = new Vector3(negMoveY.x, negMoveY.y, negMoveY.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(negMY, Space.Self);

        Vector3 jump = new Vector3(jumpHeight.x, jumpHeight.y, jumpHeight.z) * jumpSpeed *  playerSpeed * -gravity * Time.deltaTime;



        if (jumpingAllowed && controls.Player.Jump.triggered && isJumping == false)
        {

            //playerRB.MovePosition(jump * -gravity * jumpSpeed * Time.deltaTime);
            transform.Translate(jump * -gravity * Time.deltaTime, Space.World);
            isJumping = true;
            
        }
        else { isJumping = false; }

       // if (controls.Player.Jump.triggered) { Jump(); }

         //if (isStanding) { StandIdle(); }
         //else if (isFallingIdle) { FallingIdle(); }

        if (isFallingIdle) { FallingIdle(); if (controls.Player.MoveX.triggered ||
                                                controls.Player.MoveY.triggered ||
                                                controls.Player.MoveNegativeX.triggered ||
                                                controls.Player.MoveNegativeY.triggered)
                                                {
                                                    isSwimming = true;
                                                    isWalking = false;
                                                    Swim();
                                                }
                                            //else { isSwimming = false; StopSwimming(); }
        jumpingAllowed = false;
            //if (isStanding) { /*StandIdle();*/ } 
        }

        if (isStanding) { StandIdle(); if (controls.Player.MoveX.triggered ||
                                           controls.Player.MoveY.triggered ||
                                           controls.Player.MoveNegativeX.triggered ||
                                           controls.Player.MoveNegativeY.triggered)
                                                {
                                                    isWalking = true;
                                                    isSwimming = false;
                                                    Walk();
                                                }
                                       //else { isWalking = false; StopWalking(); }
        jumpingAllowed = true;
        //    if (isFallingIdle) { StandtoFall();/* FallingIdle();*/ }
        }

       //if (isSwimming)
       // {
            
       // }
       //else if (isWalking)
       // {
           
       // }
       // else { return; }
       if (isJumping)
        {
            Jump();
        }
       if (hardFall1)
        {
            HardFall1();
            hardFall1 = false;
        }

       if (hardFall2)
        {
            HardFall2();
            hardFall2 = false;
        }


    }
    public void Walk()
    {
        ResetStates();
        playerAnimator.SetBool("isWalking", true);
        playerAnimator.SetBool("isSwimming", false);
    }
    public void StopWalking()
    {
        playerAnimator.SetBool("isWalking", false);
        //playerAnimator.SetBool("isSwimming", true);
    }
    void Jump()
    {
        ResetStates();
        playerAnimator.SetBool("isJumping", true);
    }
    void StopJumping()
    {
        playerAnimator.SetBool("isJumping", false);
    }
    public void StandtoFall()
    {
        ResetStates();
        playerAnimator.SetBool("isStandtoFall", true);
        playerAnimator.SetBool("isLanding", false);
        FallingIdle();
    }
    public void Land()
    {
        ResetStates();
        playerAnimator.SetBool("isLanding", true);
        playerAnimator.SetBool("isStandtoFall", false);
        StandIdle();
    }
    public void FallingIdle()
    {
        ResetStates();
        playerAnimator.SetBool("isStandingIdle", false);
        playerAnimator.SetBool("isFallingIdle", true);
    }
   
    public void StandIdle()
    {
        ResetStates();
        playerAnimator.SetBool("isFallingIdle", false);
        playerAnimator.SetBool("isStandingIdle", true);
    }
    public void Swim()
    {
        ResetStates();
        playerAnimator.SetBool("isSwimming", true);
        playerAnimator.SetBool("isWalking", false);
    }
    void StopSwimming()
    {
        //playerAnimator.SetBool("isWalking", true);
        playerAnimator.SetBool("isSwimming", false);
    }

    public void HardFall1()
    {
        ResetStates();
        playerAnimator.SetBool("isLandingHard1", true);
    }
    void StopHardFall1()
    {
        playerAnimator.SetBool("isLandingHard1", false);
    }
    public void HardFall2()
    {
        ResetStates();
        playerAnimator.SetBool("isLandingHard2", true);
    }
    void StopHardFall2()
    {
        playerAnimator.SetBool("isLandingHard2", false);
    }
    void StopFallingIdle()
    {
        playerAnimator.SetBool("isFallingIdle", false);
    }
    void StopStandingIdle()
    {
       
        playerAnimator.SetBool("isStandingIdle", false);
    }
    void StopLanding()
    {
       
        playerAnimator.SetBool("isLanding", false);
    }
    void StopStandtoFall()
    {
      
        playerAnimator.SetBool("isStandtoFall", false);
    }
    
    void ResetStates()
    {
        StopStandingIdle();
        StopFallingIdle();
        StopLanding();
        StopStandtoFall();
        StopSwimming();
        StopWalking();
        StopJumping();
        StopHardFall1();
        StopHardFall2();
    }

    void OnEnable()
    {
        controls.Player.Enable();

    }
    void OnDisable()
    {
        controls.Player.Disable();
    }

   
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isStanding = true;
            isFallingIdle = false;
            Debug.Log("Started Standing.");
        }
        
    }
    public void OnCollisionExit(Collision collision)
    {
        isStanding = false;
        isFallingIdle = true;
        Debug.Log("Started Falling.");
    }
}

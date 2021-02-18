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
    [SerializeField] float floatHeight;

    [SerializeField] bool isFallingIdle;
    [SerializeField] public bool isStanding;
    [SerializeField] public bool isSwimming;
    [SerializeField] public bool isWalking;
    [SerializeField] public bool hardFall1;
    [SerializeField] public bool hardFall2;
    [SerializeField] public bool floatingUp;
    [SerializeField] public bool noseDiving;

    public float gravity;
    public float defaultGravity;

    public bool jumpingAllowed;
    public bool isJumping;

    public Vector3 moveX;
    public Vector3 negMoveX;
    public Vector3 moveY;
    public Vector3 negMoveY;
    
    public Vector3 playerRotation;

    public Vector3 fallSpeedReduction;

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
        defaultGravity = -9.81f;
        gravity = -9.81f;
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

        controls.Player.Float.performed += context => FloatUp();
        controls.Player.Float.canceled += context => fallSpeedReduction = Vector3.zero;

        controls.Player.NoseDive.performed += context => NoseDive();
        controls.Player.NoseDive.canceled += context => fallSpeedReduction = Vector3.zero;

    }
    public void FloatUp() { 
    
        transform.Translate(Vector3.up * floatHeight * (-gravity/1.5f) * playerSpeed *Time.deltaTime);
        floatingUp = true;
        FloatingUp();
    }
    public void NoseDive()
    {
        transform.Translate(Vector3.down * floatHeight * (-gravity * 1.5f) * playerSpeed * Time.deltaTime);
        noseDiving = true;
        NoseDiving();
        
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



        if (jumpingAllowed && controls.Player.Jump.triggered/* && isJumping == false*/)
        {
            transform.Translate(jump * -gravity * Time.deltaTime, Space.World);
            isJumping = true;
            floatingUp = false;
            noseDiving = false;
            Jump();
            
        }
        else { isJumping = false; }


        if (isFallingIdle )
        {
            FallingIdle(); if (controls.Player.MoveX.triggered ||
                                controls.Player.MoveY.triggered ||
                                controls.Player.MoveNegativeX.triggered ||
                                controls.Player.MoveNegativeY.triggered)
            {
                isSwimming = true;
                isWalking = false;
                Swim();
            }
                            if (controls.Player.Float.triggered)
                                {
                                  FloatingUp();
                                }
        jumpingAllowed = false;

            
        }
        else
        {
            isSwimming = false; StopSwimming();
            //floatingUp = false; StopFloatingUp();
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
                                            if (controls.Player.Float.triggered)
                                            {
                                                  FloatingUp();
                                            }
            jumpingAllowed = true;
        
        }
        else
        {
            isWalking = false; StopWalking();
           // floatingUp = false; StopFloatingUp();
        }

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
        //if (floatingUp)
        //{
        //    FloatingUp();
        //    //floatingUp = false;
        //}
        
        //if (noseDiving)
        //{
        //    NoseDiving();
        //    //noseDiving = false;
        //}


    }
    public void FloatingUp()
    {
        ResetStates();
        playerAnimator.SetBool("isFloatingUp", true);
        playerAnimator.SetBool("isNoseDiving", false);
    }
    void StopFloatingUp()
    {
        playerAnimator.SetBool("isFloatingUp", false);
    }
    public void NoseDiving()
    {
        ResetStates();
        playerAnimator.SetBool("isNoseDiving", true);
        playerAnimator.SetBool("isFloatingUp", false);
    }
    void StopNoseDiving()
    {
        playerAnimator.SetBool("isNoseDiving", false);
        //playerAnimator.SetBool("isFloatingUp", true);
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
        StopNoseDiving();
        StopFloatingUp();
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

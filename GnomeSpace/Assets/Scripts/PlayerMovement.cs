using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CameraController camController;
    //[SerializeField] private GameObject camera;
    //[SerializeField] private GameObject playerGO;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Animator playerAnimator;
    public float playerSpeed;
    //[SerializeField] private MouseLook m_mouseLook;
    public SpaceGnome_02_InputActions controls;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Vector3 jumpHeight;
    //[SerializeField] private Vector3 xAxisRotMax, xAxisRotMin;
    public bool isFallingIdle;
    public bool isStanding;
    public float gravity;
    public bool jumpingAllowed;
    public bool isJumping;
    Vector3 move;
    Vector3 moveX;
    Vector3 negMoveX;
    Vector3 moveY;
    Vector3 negMoveY;
    public Vector3 playerRot;
    [SerializeField] Vector3 playerRotation;

    //Vector3 originalPos;
    Quaternion originalRot;

   

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
        playerSpeed = 2f;
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
        controls.Player.Rotate.performed += context => playerRot = context.ReadValue<Vector2>();
        controls.Player.Rotate.canceled += context => playerRot = Vector2.zero;

        //Rotate Left => Left Bumper
        //Rotate Right => Right Bumper
        controls.Player.RotateLeft.performed += context => RotateLeft();
        controls.Player.RotateRight.performed += context => RotateRight();

        originalRot = transform.rotation;
    }
    public void RotateLeft()
    {
        transform.Rotate(transform.position, transform.position.y * camController.camSpeed * camController.camRotationSpeed * camController.playerRotationSpeed, Space.World);
    }
    public void RotateRight()
    {
        transform.Rotate(transform.position, -transform.position.y * camController.camSpeed * camController.camRotationSpeed * camController.playerRotationSpeed, Space.World);
    }
    
    private void Update()
    {
        Vector3 m = new Vector3(move.x, move.y, move.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(m, Space.Self);

        Vector3 mX = new Vector3(moveX.x, moveX.y, moveX.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(mX, Space.Self);

        Vector3 negMX = new Vector3(negMoveX.x, negMoveX.y, negMoveX.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(negMX, Space.Self);

        Vector3 mY = new Vector3(moveY.x, moveY.y, moveY.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(mY, Space.Self);

        Vector3 negMY = new Vector3(negMoveY.x, negMoveY.y, negMoveY.z) * playerSpeed * -gravity * Time.deltaTime;
        transform.Translate(negMY, Space.Self);

        Vector3 jump = new Vector3(jumpHeight.x, jumpHeight.y, jumpHeight.z) * jumpSpeed *  playerSpeed * -gravity * Time.deltaTime;



        playerRotation = new Vector3(playerRot.y, playerRot.x, playerRot.z);
        transform.Rotate(playerRotation, Space.Self);
        //if (controls.Player.Rotate.triggered && camController.camControls.Camera.RotateCamera.triggered) { transform.Rotate(playerRotation, Space.Self); }
        //else { return; }



        if (jumpingAllowed && controls.Player.Jump.triggered && isJumping == false)
        {

            playerRB.MovePosition(jump * -gravity * jumpSpeed * Time.time);
            //transform.Translate(jump, Space.World);
            isJumping = true;
        }
        else { isJumping = false; }

        /* */

       
        //if (transform.rotation.x >= 360) { transform.SetPositionAndRotation(transform.position, originalRot); }
        //if (transform.rotation.x <= -360) { transform.SetPositionAndRotation(transform.position, originalRot); }
        //if (transform.rotation.y >= 360) { transform.SetPositionAndRotation(transform.position, originalRot); }
        //if (transform.rotation.y <= -360) { transform.SetPositionAndRotation(transform.position, originalRot); }
        //if (transform.rotation.z >= 360) { transform.SetPositionAndRotation(transform.position, originalRot); }
        //if (transform.rotation.z <= -360) { transform.SetPositionAndRotation(transform.position, originalRot); }

        if (isFallingIdle) { FallingIdle(); jumpingAllowed = false; }

        if (isStanding) { StandIdle(); jumpingAllowed = true; /*transform.Rotate(originalRot.x, originalRot.y, originalRot.z, Space.Self);*/
            //if (!controls.Player.Move.triggered && !controls.Player.MoveX.triggered &&
            //    !controls.Player.MoveNegativeX.triggered && !controls.Player.MoveY.triggered &&
            //    !controls.Player.MoveNegativeY.triggered && !controls.Player.Jump.triggered && !controls.Camera.Rotate.triggered)
            //    {camRotation.transform.RotateAround(transform.position, camRotation.transform.rotation.z);}
        }
        //else if (!isStanding) { transform.Rotate(originalRot.x, originalRot.y, originalRot.z, Space.Self); }

        //if (transform.rotation.y >= 120 || transform.rotation.y <= -120) { transform.SetPositionAndRotation(transform.position, originalRot); }


    }
    private void FixedUpdate()
    {


        //Vector3 xAxisRot = Vector3.Lerp(xAxisRotMax, xAxisRotMin, transform.rotation.x);
        Quaternion resetRot = new Quaternion(playerRotation.x * camController.camSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        playerRB.transform.SetPositionAndRotation(transform.position, resetRot );
    }
    public void StandtoFall()
    {
        ResetStates();
        playerAnimator.SetBool("isStandtoFall", true);
    }
    public void FallingIdle()
    {
        ResetStates();
        playerAnimator.SetBool("isStandingIdle", false);
        playerAnimator.SetBool("isFallingIdle", true);
    }
    void Land()
    {
        ResetStates();
        playerAnimator.SetBool("isLanding", true);
    }
    void StandIdle()
    {
        ResetStates();
        playerAnimator.SetBool("isFallingIdle", false);
        playerAnimator.SetBool("isStandingIdle", true);
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
    }

    void OnEnable()
    {
        controls.Player.Enable();

    }
    void OnDisable()
    {
        controls.Player.Disable();
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other)
    //    {
    //        isStanding = true;
    //        isFallingIdle = false;
    //    }
    //    else if (!other)
    //    {
    //        isStanding = false;
    //        isFallingIdle = true;
    //    }

    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other)
    //    {
    //        isStanding = false;
    //        isFallingIdle = true;
    //    }
    //    else if (!other)
    //    {
    //        isStanding = true;
    //        isFallingIdle = false;
    //    }
    //}

    public void OnCollisionEnter(Collision collision)
    {
        isStanding = true;
        isFallingIdle = false;
        Debug.Log("Started Standing.");
    }
    public void OnCollisionExit(Collision collision)
    {
        isStanding = false;
        isFallingIdle = true;
        Debug.Log("Started Falling.");
    }
}

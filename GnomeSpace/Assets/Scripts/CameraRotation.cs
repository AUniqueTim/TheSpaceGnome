using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    public SpaceGnome_02_InputActions camControls;
    public PlayerMovement m_playerMovement;

    Vector3 playerRot;
    public Vector3 camRot;
    //Vector3 camXRot;

    //[SerializeField] private float maxXRot;
   // [SerializeField] private float maxYRot;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private float camRotationSpeed;
    public float camSpeed;
    
    public GameObject player;
    public GameObject cam;
    Vector2 camYRot;

    public void Awake()
    {
        camControls = new SpaceGnome_02_InputActions();

        camControls.Camera.RotateCamera.performed += ctx => camRot = ctx.ReadValue<Vector2>();
        camControls.Camera.RotateCamera.canceled += ctx => camRot = Vector2.zero;
        camControls.Camera.Rotate.performed += ctx => playerRot = ctx.ReadValue<Vector2>();
        camControls.Camera.Rotate.canceled += ctx => playerRot = Vector2.zero;
      //  camControls.Camera.RotateCameraOnXAxis.performed += ctx => camYRot = ctx.ReadValue<Vector2>();
      //  camControls.Camera.RotateCameraOnXAxis.canceled += ctx => camYRot = Vector2.zero;
    }
    //public void RotateOnX()
    //{
    //    transform.Rotate(0, 25, 0);
    //}
    private void Update()
    {
        //Vector3 camRotation = new Vector3(camRot.y, camRot.x, camRot.z);
      //  transform.Rotate(camRotation * camSpeed * camRotationSpeed * Time.deltaTime, Space.World);
        
       // transform.Rotate(camRotation * camSpeed * Time.deltaTime, Space.Self);
       //transform.Rotate(camRotation * camSpeed * Time.deltaTime, Space.Self);
        Vector3 playerRotation = new Vector3(playerRot.y, playerRot.x, playerRot.z);
        //if (camControls.Camera.Rotate.triggered) { player.transform.Rotate(playerRotation * playerRotationSpeed * camSpeed * Time.deltaTime, Space.Self); }
       player.transform.Rotate(playerRotation * playerRotationSpeed * camSpeed * Time.deltaTime, Space.World);
        //player.transform.Translate(playerRotation * camRotationSpeed * camSpeed * Time.deltaTime, Space.World);
        //transform.Rotate(playerRotation * playerRotationSpeed * camSpeed * Time.deltaTime, Space.World);
        //transform.Rotate(playerRotation * camSpeed * Time.deltaTime, Space.Self);
        // Vector3 cameraYRotation = new Vector3(camYRot.x, camYRot.y);
        //transform.Rotate(cameraXRotation * camSpeed * Time.deltaTime);
        //        transform.Rotate(cameraXRotation + transform.position * camSpeed * Time.deltaTime, Space.Self);
        //      if (camControls.Camera.RotateCameraOnXAxis.triggered) {  }
        //  transform.RotateAround(player.transform.position, cameraYRotation, cameraYRotation.y);

        // player.transform.Rotate(cameraXRotation * camSpeed * Time.deltaTime, Space.Self);

        //if (camRotation.x >= maxXRot)
        //{
        //    camRotation.x = maxXRot;
        //}
        //if (camRotation.y >= maxYRot)
        //{
        //    camRotation.y = maxYRot;
        //}

    }

    public  void OnEnable()
    {
        camControls.Camera.Enable();
    }
   public void OnDisable()
    {
        camControls.Camera.Disable();
    }
}

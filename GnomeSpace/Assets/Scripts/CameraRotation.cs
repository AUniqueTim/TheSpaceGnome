using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public SpaceGnome_02_InputActions camControls;
    public PlayerMovement m_playerMovement;

    Vector3 playerRot;
    public Vector3 camRot;
    Vector3 camXRot;

    [SerializeField] private float maxXRot;
    [SerializeField] private float maxYRot;

    public float camSpeed;
    
    public GameObject player;
    public GameObject cam;


    public void Awake()
    {
        camControls = new SpaceGnome_02_InputActions();

        camControls.Camera.RotateCamera.performed += ctx => camRot = ctx.ReadValue<Vector2>();
        camControls.Camera.RotateCamera.canceled += ctx => camRot = Vector2.zero;
        camControls.Camera.Rotate.performed += ctx => playerRot = ctx.ReadValue<Vector2>();
        camControls.Camera.Rotate.canceled += ctx => playerRot = Vector2.zero;
        camControls.Camera.RotateCameraOnXAxis.performed += ctx => camXRot = Vector3.right;
        camControls.Camera.RotateCameraOnXAxis.canceled += ctx => camXRot = Vector2.zero;
    }

    private void Update()
    {
        Vector3 camRotation = new Vector3(camRot.x, camRot.y, camRot.z);
        Vector3 playerRotation = new Vector3(playerRot.y, playerRot.x, playerRot.z);
        Vector3 cameraXRotation = new Vector3(camXRot.x, camXRot.y, camXRot.z);
        //transform.RotateAround(camRotation * camSpeed * Time.deltaTime, player.transform.position.x);
        player.transform.Rotate(playerRotation * camSpeed * Time.deltaTime, Space.World);
        transform.Rotate(camRotation * camSpeed * Time.deltaTime, Space.World);
        transform.Rotate(cameraXRotation * camSpeed * Time.deltaTime, Space.World);
        //player.transform.rotation = transform.rotation;

        if (camRotation.x >= maxXRot)
        {
            camRotation.x = maxXRot;
        }
        if (camRotation.y >= maxYRot)
        {
            camRotation.y = maxYRot;
        }

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

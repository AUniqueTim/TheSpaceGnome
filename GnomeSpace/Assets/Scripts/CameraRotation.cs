using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public CameraControls camControls;

    public Vector3 camRot;
    [SerializeField] private float camSpeed;
    [SerializeField] private float maxXRot;
    [SerializeField] private float maxYRot;
    public GameObject player;


    public void Awake()
    {
        camControls = new CameraControls();
        camControls.Camera.Rotate.performed += ctx => camRot = ctx.ReadValue<Vector2>();
        camControls.Camera.Rotate.canceled += ctx => camRot = Vector2.zero;
    }

    private void Update()
    {
        Vector3 camRotation = new Vector3(camRot.y, camRot.x, camRot.z);
        transform.RotateAround(camRotation.normalized * camSpeed * Time.deltaTime, player.transform.rotation.y);
        player.transform.Rotate(camRotation.normalized * camSpeed * Time.deltaTime, Space.World);
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

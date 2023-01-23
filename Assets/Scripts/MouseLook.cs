using UnityEngine;
using UnityEngine.InputSystem; 

public class MouseLook : MonoBehaviour
{
    public float ZoomCameraInput { get; private set; } = 0.0f;
    private float mouseSensitivity = 20.0f;
    private float mouseZoomSensitivity = 10f;
    private Vector2 mouseLook, mouseZoomLook;
    private Transform playerBody;
    private My_First_Person_Player_Controls controls; /* The use of this My_First_Person_Player_Controls() 
                                                         allows to access the Player_Controller only by using script
                                                         there is no need to set the Player Input component */
    private float xRotation = 0.0f;


    private void Awake()
    {
        playerBody = transform.parent;
        controls = new My_First_Person_Player_Controls();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Look()
    {
        mouseLook = controls.Player.Camera_Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector2.up * mouseX);
    }

    private void Zoom() // WIP
    {
        mouseZoomLook = controls.Player.Camera_Look.ReadValue<Vector2>();
        float zoomFactor = mouseZoomLook.sqrMagnitude * mouseZoomSensitivity * Time.deltaTime;
        //transform.localPosition = Vector2.zero;
        
        // Debug.Log("mouseZoomLook = " + mouseZoomLook);
        // Debug.Log("zoomFactor = " + zoomFactor);
    }

    private void SetZoomCamera(InputAction.CallbackContext context)
    {
        ZoomCameraInput = context.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 mouseCursorPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = mouseCursorPosition;
        Look();
        Zoom();
    }
}

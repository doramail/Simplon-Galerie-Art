using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder;
using static UnityEngine.InputSystem.InputAction;

public class First_Person_Player_Behaviour_Control : MonoBehaviour
{
    public float _mouseZoomScrollY;
    public MouseZoom _mouseZoom;
    public Transform ground;
    public LayerMask groundMask;
    public float distanceToGround = 0.4f;
    public float ZoomCameraInput { get; private set; } = 0.0f;

    private bool isZoomed = false;
    private bool notZoomed = true;

    private My_First_Person_Player_Controls controls;/* The use of this My_First_Person_Player_Controls() 
                                                        allows to access the Player_Controller only by using script
                                                        there is no need to set the Player Input component */
    private Vector3 velocity;
    private float gravity = -9.81f;
    private Vector2 move;
    public Vector2 _mouseZoomFromContext;

    private CharacterController controller;
    private bool isGrounded;

    private float movespeed = 06f;
    // private float JumpHeight = 2.4f;

    public bool _mouseContext;
    public float zoomCameraInput { get; private set; } = 0.0f;
    public int zoom = 20;
    public int normal = 60;
    public float smooth = 5;


    private void Awake()
    {
        controls = new My_First_Person_Player_Controls();
        controller = GetComponent<CharacterController>();
        controls.Player.MouseZoomScrollY.performed += x => _mouseZoomScrollY = x.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        //PlayerMovement();
        MovePlayer();
        //JumpH();
        TestScrollMouse();
    }

    private void TestScrollMouse()
    {
        Debug.Log("_mouseZoomScrollY received is : " + _mouseZoomScrollY);
       _mouseZoom.TestScrollMouse(_mouseZoomScrollY);
        //if (_mouseZoomScrollY > 0)
        //{
        //    Debug.Log("scrolled up");
        //}
        //if (_mouseZoomScrollY < 0)
        //{
        //    Debug.Log("scrolled down");
        //}
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void PlayerMovement(InputAction.CallbackContext callbackContext)
    {
        move = callbackContext.ReadValue<Vector2>();
        /* Or you can use these three lines and reactivate the PlayerMovement() line in the Update function: 
        
        move = controls.Player.Player_Movement.ReadValue<Vector2>();
        Vector3 distance = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(distance * movespeed * Time.deltaTime);

        */
    }


    public void OnMouseWheelAction(InputAction.CallbackContext mouseContext)
    {
        //_mouseZoomFromContext = mouseContext.ReadValue<Vector2>();
        //_mouseZoom._mouseScrollZoomFromContext = _mouseZoomFromContext;
        //_mouseZoom.ZoomCamera();
        TestScrollMouse();
    }



    private void MovePlayer()
    {
        Vector3 distance = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(distance * movespeed * Time.deltaTime);
    }

    //private void JumpH()
    //{

    //if (controls.Player.Jump.triggered)  // Jump not used here, no need to jum inside a Galerie !
    //{
    //    velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
    //}
    //}

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}

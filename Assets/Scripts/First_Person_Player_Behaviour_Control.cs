using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class First_Person_Player_Behaviour_Control : MonoBehaviour
{
    public Transform ground;
    public LayerMask groundMask;
    public float distanceToGround = 0.4f;

    private My_First_Person_Player_Controls controls;/* The use of this My_First_Person_Player_Controls() 
                                                        allows to access the Player_Controller only by using script
                                                        there is no need to set the Player Input component */
    private float mouveSpeed = 06.0f;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private Vector2 move;

    private CharacterController controller;
    private bool isGrounded;

    private float movespeed = 10f;
    private float JumpHeight = 2.4f;

    private void Awake()
    {
        controls = new My_First_Person_Player_Controls(); 
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Gravity();
        PlayerMovement();
        JumpH();
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
    private void PlayerMovement()
    {
        move = controls.Player.Player_Movement.ReadValue<Vector2>();
        Vector3 distance = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(distance * movespeed * Time.deltaTime);
    }
    private void JumpH()
    {

        //if (controls.Player.Jump.triggered)  // Jump not used here, no need to jum inside a Galerie !
        //{
        //    velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        //}
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {

    }
}

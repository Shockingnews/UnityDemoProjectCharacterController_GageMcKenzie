using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{


    static float acceleration;
    static float deceleration;
    public float playerspeed = 5;
    public float playerspeedMax = 10;
    public float playerspeedMin = 5;

    static float gravity = -100f;
    static float ymovement;

    static Vector2 movementInput;
    static Vector3 movePlayer;
    static float smoothTime = 0.1f;
    static float test = 0.1f;
    

    static CharacterController controller;

    public InputActionReference movement;
    public InputActionReference sprint;
    public InputActionReference Jump;
    public InputActionReference Crounch;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Gets the controller adds it to the game object
        controller = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 lookingPos = new Vector3(movePlayer.x, 0.0f, movePlayer.z);
        Quaternion currentRot = transform.rotation;
        Quaternion targetRot = Quaternion.LookRotation(lookingPos);
        transform.rotation = Quaternion.Slerp(currentRot, targetRot, 15f * Time.deltaTime);

        bool isGrounded = controller.isGrounded;
        
        //else { ymovement += gravity * Time.deltaTime; }
            
        // gets the input from the player and reads it out
        Vector2 movementInput = movement.action.ReadValue<Vector2>();
        float sprintInput = sprint.action.ReadValue<float>();
        if (sprintInput == 1) 
        {
            float moreSpeed = Vector3.MoveTowards(playerspeedMin, playerspeedMax, acceleration * Time.deltaTime);
            movePlayer = new Vector3(movementInput.x *moreSpeed, gravity * Time.deltaTime, movementInput.y * moreSpeed) * Time.deltaTime * playerspeed; }

        //if () 
        //{
        //    movePlayer = new Vector3(movementInput.x * 3f, 0.0f, movementInput.y * 3f) * Time.deltaTime * playerspeed;
        //}
        else { movePlayer = new Vector3(movementInput.x, gravity * Time.deltaTime, movementInput.y) * Time.deltaTime * playerspeed; }
        float JumpInput = Jump.action.ReadValue<float>();
        if (controller.isGrounded)
        {
            if (JumpInput == 1)
            {
                movePlayer = new Vector3(movementInput.x, 10.0f, movementInput.y) * Time.deltaTime * playerspeed;
            }
        }
        
        float crounchInput = Crounch.action.ReadValue<float>();
        if (crounchInput == 1)
        {
            controller.height = 0.05f;
            
        }
        else
        {
            controller.height = 1.0f;
            
        }

        // gets the x and y values of the player input and puts in a 3d space




        // moves where player is facing

        //var targetAgnles = (movePlayer.x, movePlayer.z);
        //var angles = Mathf.SmoothDamp(transform.forward, targetAgnles, ref test, smoothTime);
        //transform.rotation = Quaternion.Euler(0.0f,angles,0.0f);
        // makes movement faster
        //movePlayer.y = gravity * Time.deltaTime;

            controller.Move(movePlayer);
    }
    static void Rotation()
    {
        
    }
}

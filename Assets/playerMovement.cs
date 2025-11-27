using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{

    // how much sppeed can go by before hitting max
    public float acceleration = 5f;
    // how much sppeed can go by before hitting min
    public float deceleration = 5f;
    // currnt speed
    public float playerspeed = 5;
    // max and min of speed
    public float playerspeedMax = 20f;
    public float playerspeedMin = 5;

    static float gravity = -9.15f;
    
    // keeps track of inputs of movement
    static Vector2 movementInput;
    // rotates the player
    static float xRotation;
    static float yRotation;
    // moves player
    static Vector3 move;
    // actives gravity
    static Vector3 volacity;

    // the controller
    static CharacterController controller;
    // all player inputs
    public InputActionReference movement;
    public InputActionReference sprint;
    public InputActionReference Jump;
    public InputActionReference Crounch;
    public InputActionReference mouse;
    // camera
    public GameObject cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // hides cursor
        Cursor.visible = false;

        // Gets the controller adds it to the game object
        controller = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        // reads were the mouse is positioned in game
        Vector2 mouseInput = mouse.action.ReadValue<Vector2>();
        
        // keeps input  of mouse
        yRotation = mouseInput.x;
        xRotation = -mouseInput.y;

        // gives you a limt on up and down movement
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotates cam and player in the direction of mouse
        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.rotation = Quaternion.Euler(0, yRotation, 0f);

         

       
        // checks for wasd inputs
        Vector2 movementInput = movement.action.ReadValue<Vector2>();
        
        
        
        // checks for space input
        float JumpInput = Jump.action.ReadValue<float>();

        // if player on the ground you can access the next part
        if (controller.isGrounded)
        {
            // if you pressed space once move player up 
            if (JumpInput == 1)
            {
                move = transform.up * 5f + transform.right* movementInput.x + transform.forward * movementInput.y;
            }
        }
        
        // checks for ctrl input
        float crounchInput = Crounch.action.ReadValue<float>();
        // if ctrl held or pressed crouch
        if (crounchInput == 1)
        {
            controller.height = 1.5f;

            // decreases the speed by deceleration every second
            playerspeed = Mathf.MoveTowards(playerspeed, playerspeedMin, deceleration * Time.deltaTime);
            move = transform.right * movementInput.x + transform.forward * movementInput.y;

        }
        // if not crounched
        else
        {
            // keeps player height
            controller.height = 2.0f;
            
            //checks for shift input
            float sprintInput = sprint.action.ReadValue<float>();
            // if held or pressed sprint
            if (sprintInput == 1)
            {
                // increases the speed by acceleration every second
                playerspeed = Mathf.MoveTowards(playerspeed, playerspeedMax, acceleration * Time.deltaTime);
                // moves player on the x and z axis
                move = transform.right * movementInput.x + transform.forward * movementInput.y;


                

            }

            // if not held or pressed
            else
            {
                // decreases the speed by deceleration every second
                playerspeed = Mathf.MoveTowards(playerspeed, playerspeedMin, deceleration * Time.deltaTime);
                move = transform.right * movementInput.x + transform.forward * movementInput.y;
            }
        }
        // gravity increses every second andds it to volacity
        volacity.y = gravity * Time.deltaTime;
        




        
        // moves player in currnt direction and by currnt speed
        controller.Move(move * Time.deltaTime * playerspeed);
        // adds gravity
        controller.Move(volacity);
    }
    
}

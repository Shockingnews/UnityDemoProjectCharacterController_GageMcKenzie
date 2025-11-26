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

    static float gravity = -9.81f;
    static float ymovement;

    static Vector2 movementInput;
    static Vector3 movePlayer;
    static float smoothTime = 0.1f;
    static float test = 0.1f;

    private CharacterController controller;

    public InputActionReference movement;
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
        if (controller.isGrounded)
        {
            gravity = -9.81f;
        }
        else { ymovement += gravity * Time.deltaTime; }
            
        // gets the input from the player and reads it out
        Vector2 movementInput = movement.action.ReadValue<Vector2>();
        // gets the x and y values of the player input and puts in a 3d space
        movePlayer = new Vector3(movementInput.x, 0, movementInput.y);

        

        // moves where player is facing
        transform.forward = movePlayer;
        var targetAgnles = (movePlayer.x, movePlayer.z);
        var angles = Mathf.SmoothDamp(transform.forward, targetAgnles, ref test, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f,angles,0.0f);
        // makes movement faster
        Vector3 newmovement = (playerspeed * movePlayer);
        controller.Move(newmovement * Time.deltaTime);
    }
}

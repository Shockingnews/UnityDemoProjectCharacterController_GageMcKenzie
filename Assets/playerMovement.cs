using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{


    static float acceleration;
    static float deceleration;
    public float playerspeed = 5;

    

    private CharacterController controller;

    public InputActionReference movement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Gets the controller adds it to the game object
        controller = gameObject.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        // gets the input from the player and reads it out
        Vector2 movementInput = movement.action.ReadValue<Vector2>();
        // gets the x and y values of the player input and puts in a 3d space
        Vector3 movePlayer = new Vector3(movementInput.x, 0, movementInput.y);

        

        // moves where player is facing
        transform.forward = movePlayer;

        // makes movement faster
        Vector3 newmovement = (playerspeed * movePlayer);
        controller.Move(newmovement * Time.deltaTime);
    }
}

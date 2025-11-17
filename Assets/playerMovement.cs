using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    

    static float acceleration;
    static float deceleration;
    static int playerspeed = 5;

    public GameObject player;

    private CharacterController controller;

    public InputActionReference movement;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Vector3.MoveTowards();
        controller = gameObject.AddComponent<CharacterController>();
    }
    
    private void OnEnable()
    {
        movement.action.Enable();
    }
    private void OnDisable()
    {
        movement.action.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = movement.action.ReadValue<Vector2>();
        Vector3 movePlayer = new Vector3(movementInput.x, 0, movementInput.y);

        movePlayer = Vector3.ClampMagnitude(movePlayer, 1f);

        if(movePlayer != Vector3.zero)
        {
            transform.forward = movePlayer;
        }

        Vector3 newmovement = (playerspeed * movePlayer);
         controller.Move(newmovement * Time.deltaTime);
    }
}

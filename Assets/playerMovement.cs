using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    

    static float acceleration;
    static float deceleration;
    public int playerspeed = 5;

    

    private CharacterController controller;

    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        controller = GetComponent<CharacterController>();
    }
    
   
    // Update is called once per frame
    void Update()
    {
        
        Vector3 movePlayer = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        
         controller.Move(movePlayer * Time.deltaTime * playerspeed);
    }
}

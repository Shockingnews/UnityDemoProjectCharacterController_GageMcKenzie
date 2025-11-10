using UnityEngine;

public class playerMovement : MonoBehaviour
{
    static float Xmovement;
    static float Zmovement;

    static float acceleration;
    static float deceleration;

    static Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            Xmovement += 1;
            Vector3 test = new Vector3(Xmovement, 0f, Zmovement);

            transform.position = Vector3.MoveTowards(transform.position, test,1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Xmovement -= 1;
            Vector3 test = new Vector3(Xmovement, 0f, Zmovement);

            transform.position = test;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Zmovement -= 1;
            Vector3 test = new Vector3(Xmovement, 0f, Zmovement);

            transform.position = test;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Zmovement += 1;
            Vector3 test = new Vector3(Xmovement, 0f, Zmovement);

            transform.position = test;
        }
    }
}

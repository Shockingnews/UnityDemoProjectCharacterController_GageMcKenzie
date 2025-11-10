using UnityEngine;

public class playerMovement : MonoBehaviour
{
    static float Xmovement;

    static Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Xmovement += 1;
            Vector3 test = new Vector3(Xmovement, 0f, 0f);

            transform.position = test;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Xmovement += 1;
            Vector3 test = new Vector3(Xmovement, 0f, 0f);

            transform.position = test;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Xmovement += 1;
            Vector3 test = new Vector3(Xmovement, 0f, 0f);

            transform.position = test;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Xmovement += 1;
            Vector3 test = new Vector3(Xmovement, 0f, 0f);

            transform.position = test;
        }
    }
}

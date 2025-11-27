using UnityEngine;

public class camPosscript : MonoBehaviour
{
    
    
    public GameObject player;
    
    
    void Start()
    {
        transform.position = player.transform.position;
    }

    
    void Update()
    {
        transform.position = player.transform.position;
    }
}

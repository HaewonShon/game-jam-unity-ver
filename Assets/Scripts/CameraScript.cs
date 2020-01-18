using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        Vector2 playerPos = player.transform.position;
        Vector3 cameraPos = transform.position;

        if(playerPos.x > cameraPos.x + 10)
        {
            transform.position = new Vector3(cameraPos.x + 20, cameraPos.y, cameraPos.z);
        }
        else if(playerPos.x < cameraPos.x - 10)
        {
            transform.position = new Vector3(cameraPos.x - 20, cameraPos.y, cameraPos.z);
        }

        if(playerPos.y > cameraPos.y + 7)
        {
            transform.position = new Vector3(cameraPos.x, cameraPos.y + 14, cameraPos.z);
        }
        else if(playerPos.y < cameraPos.y - 7)
        {
            transform.position = new Vector3(cameraPos.x, cameraPos.y - 14, cameraPos.z);
        }
    }
}

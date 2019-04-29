using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{ 
    public GameObject player;
    private float deltaX;
    private float cameraY;
    private float cameraZ;
    public float deltaY;

    // Start is called before the first frame update
    void Start()
    {
        deltaX = Mathf.Abs(player.transform.position.x - transform.position.x);
        //deltaY = Mathf.Abs(transform.position.y - player.transform.position.y);
        
        cameraY = transform.position.y;
        cameraZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        yFollow();
        setCameraPosition();
    }

    public void setCameraPosition()
    {
        transform.position = new Vector3(player.transform.position.x + deltaX, cameraY, cameraZ);
    }

    void yFollow()
    {
        if(player.transform.position.y < transform.position.y + deltaY)
        {
            cameraY = player.transform.position.y + deltaY;
        }
        else if (player.transform.position.y > transform.position.y - deltaY)
        {
            cameraY = player.transform.position.y - deltaY;
        }
    }
}

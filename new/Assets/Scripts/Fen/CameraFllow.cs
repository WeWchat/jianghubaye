using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    public Transform player;
    private Vector3 Pos;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public float cameraZ;
    // Update is called once per frame
    void Update()
    {
        FixCameraPos();
    }
    void FixCameraPos()
    {
        Pos = player.transform.position;
        transform.position = new Vector3(Pos.x,Pos.y, cameraZ);
        if (player.position.y >= maxY)
        {
            transform.position = new Vector3(Pos.x, maxY, cameraZ);
        }
        else if (player.position.y <= minY)
        {
            transform.position = new Vector3(Pos.x, minY, cameraZ);
        }
        else if(player.position.x >= maxX)
        {
            transform.position = new Vector3(maxX, Pos.y, cameraZ);
        }
        else if (player.position.x <= minX)
        {
            transform.position = new Vector3(minX, Pos.y, cameraZ);
        }
    }
}

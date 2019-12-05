using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera gameCamera;
    
    public void ZoomIn()
    {
        gameCamera.orthographicSize--;
    }

    // Update is called once per frame
    public void ZoomOut()
    {
        gameCamera.orthographicSize++;
    }

    public void PanUp()
    {
        gameCamera.transform.Translate(Vector3.up, Space.Self);
    }
    public void PanDown()
    {
        gameCamera.transform.Translate(Vector3.down, Space.Self);
    }
    public void PanLeft()
    {
        gameCamera.transform.Translate(Vector3.left, Space.Self);
    }
    public void PanRight()
    {
        gameCamera.transform.Translate(Vector3.right, Space.Self);
    }
}

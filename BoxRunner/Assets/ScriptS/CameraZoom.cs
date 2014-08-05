using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public Camera camera;
    public GameObject player;
    public float speed = 0.5f;
    float cameraSize = 5f;
    public float MaxSize = 10f;
    public float MinSize = -5f;
    void Update()
    {
        cameraSize = 5f + player.transform.position.y;
        if(cameraSize>=MaxSize)
        { cameraSize = MaxSize; }
        if(cameraSize<=MinSize)
        { cameraSize = MinSize; }
        
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraSize, Time.deltaTime / speed);
    }
}

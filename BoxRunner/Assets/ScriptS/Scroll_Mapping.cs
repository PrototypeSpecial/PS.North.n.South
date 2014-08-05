using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{
    public float ScrollSpeed = 0.5f;
    float Target_Offset;

    void Update()
    {
        Target_Offset += Time.deltaTime * ScrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(Target_Offset, 0);
    }
}

using UnityEngine;
using System.Collections;

//2D 스프라이트 제래네이터 코드?

[ExecuteInEditMode]
public class Sprite : MonoBehaviour {
    public Vector2 spriteTopLeft;
    public Vector2 spriteSize;
    public Material spriteMaterial;
    public float defCameraPixels = 768f;
    public SpriteOrientation spriteOrientation;
    protected Mesh _mesh;
    protected MeshRenderer _renderer;
    
    void Awake()
    {
        if(spriteMaterial == null || spriteMaterial.mainTexture == null)
        {
            Debug.LogError("재질이 설정되어 있어야 합니다");
            return;
        }

        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf==null)
        {
            mf = gameObject.AddComponent<MeshFilter>();
        }
        _renderer = gameObject.GetComponent<MeshRenderer>();
        if (_renderer == null)
        {
            _renderer = gameObject.AddComponent<MeshRenderer>();
        }
        _renderer.castShadows = false;
        _renderer.receiveShadows = false;
        _renderer.sharedMaterial = spriteMaterial;

        float pixelPerWorldUnit = Camera.main.orthographicSize * 2 / defCameraPixels;
        
        _mesh = new Mesh();
        _mesh.name = "SpriteMesh";

        if (spriteOrientation == SpriteOrientation.MiddleCenter)
        {
            _mesh.vertices = new Vector3[] {
                new Vector3(-spriteSize.x, -spriteSize.y) * pixelPerWorldUnit * 0.5f,
                new Vector3(-spriteSize.x,  spriteSize.y) * pixelPerWorldUnit * 0.5f,
                new Vector3( spriteSize.x, -spriteSize.y) * pixelPerWorldUnit * 0.5f,
                new Vector3( spriteSize.x,  spriteSize.y) * pixelPerWorldUnit * 0.5f
            };
        }
        else if (spriteOrientation == SpriteOrientation.TopLeft)
        {
            _mesh.vertices = new Vector3[] {
                new Vector3(           0, -spriteSize.y) * pixelPerWorldUnit,
                new Vector3(           0,             0) * pixelPerWorldUnit,
                new Vector3(spriteSize.x, -spriteSize.y) * pixelPerWorldUnit,
                new Vector3(spriteSize.x,             0) * pixelPerWorldUnit
            };
        }
        
        _mesh.triangles = new int[] { 0, 1, 3, 0, 3, 2 };

        float texWidth = _renderer.sharedMaterial.mainTexture.width;
        float textheight = _renderer.sharedMaterial.mainTexture.height;

        _mesh.uv = new Vector2[] {
            new Vector2(1f/texWidth * (spriteTopLeft.x             ), 1f-1f/textheight * (spriteTopLeft.y+spriteSize.y)),
            new Vector2(1f/texWidth * (spriteTopLeft.x             ), 1f-1f/textheight * (spriteTopLeft.y             )),
            new Vector2(1f/texWidth * (spriteTopLeft.x+spriteSize.x), 1f-1f/textheight * (spriteTopLeft.y+spriteSize.y)),
            new Vector2(1f/texWidth * (spriteTopLeft.x+spriteSize.x), 1f-1f/textheight * (spriteTopLeft.y             ))
        };

        _mesh.Optimize();
        _mesh.RecalculateNormals();
        _mesh.RecalculateBounds();
        mf.sharedMesh = _mesh;
    }

    public enum SpriteOrientation
    {
        TopLeft,
        MiddleCenter
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}

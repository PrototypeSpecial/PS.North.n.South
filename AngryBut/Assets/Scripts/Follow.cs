using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
    public GameObject Target;
    public float Distance = 5f;
    public float Height = 8f;
    public float Speed = 2f;

    Vector3 Pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Pos = new Vector3(Target.transform.position.x, Height, Target.transform.position.z - Distance);
        //this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, Pos, Speed * Time.deltaTime);
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, Pos, Speed * Time.deltaTime);
	}
}

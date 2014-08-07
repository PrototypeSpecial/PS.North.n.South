using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour {

	public float Speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f, Speed, 0f));
	}
}

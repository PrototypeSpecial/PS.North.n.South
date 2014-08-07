using UnityEngine;
using System.Collections;

public class GunFX : MonoBehaviour {
	public Light light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		light.range = Random.Range (4f, 10f);
		transform.localScale = Vector3.one * Random.Range (2f, 4f);
		transform.localEulerAngles = new Vector3 (270f, 0, Random.Range (0f, 90.0f));
	}
}

using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public float power = 1;
    public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            GameObject NewBall = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Vector3 powerVector = transform.rotation * Vector3.right * power;
            NewBall.rigidbody.velocity = powerVector;
        }
	}


}

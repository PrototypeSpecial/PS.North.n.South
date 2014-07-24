using UnityEngine;
using System.Collections;

public class LeftRightMove : MonoBehaviour {
    public float moveSpeed = 10f;
    public float rotateSpeed = 60;

    // Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () {
        float axisx = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * axisx * moveSpeed * Time.deltaTime);

        float axisy = Input.GetAxis("Vertical");
        float currentAngle = transform.rotation.eulerAngles.z;
        currentAngle += axisy * rotateSpeed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle, 0f, 90f);
        transform.rotation = Quaternion.Euler(Vector3.forward * currentAngle);
    }


}

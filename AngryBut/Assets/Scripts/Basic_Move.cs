using UnityEngine;
using System.Collections;

public class Basic_Move : MonoBehaviour {
	
	public int Speed;
	
	void Update () {
			
		if (Input.GetKey (KeyCode.LeftArrow)) {
               transform.Translate (Vector3.left * Speed * Time.deltaTime);
          	} 		  
     	if (Input.GetKey (KeyCode.RightArrow)) {
               transform.Translate (Vector3.right * Speed * Time.deltaTime);
          	}
		if (Input.GetKey (KeyCode.UpArrow)) {
               transform.Translate (Vector3.forward * Speed * Time.deltaTime);
          	}
		if (Input.GetKey (KeyCode.DownArrow)) {
               transform.Translate (Vector3.back * Speed * Time.deltaTime);
          	}
		
	}
}
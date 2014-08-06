using UnityEngine;
using System.Collections; 

public class Move : MonoBehaviour
{
	public float MoveSpeed;
	Vector3 lookDirection;
		
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)  ||
		    Input.GetKey (KeyCode.RightArrow) ||
		    Input.GetKey (KeyCode.UpArrow)    ||
		    Input.GetKey (KeyCode.DownArrow)) 
		{
			float xx = Input.GetAxisRaw ("Vertical");
			float zz = Input.GetAxisRaw ("Horizontal");	
			lookDirection = xx * Vector3.forward + zz * Vector3.right;		
			
			this.transform.rotation = Quaternion.LookRotation (lookDirection);
			this.transform.Translate (Vector3.forward * MoveSpeed * Time.deltaTime);	
		}
	}
	
}
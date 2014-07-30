using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour {
	
	public string SceneName;
	
	public void OnMouseDown(){
	
		Application.LoadLevel( SceneName );		
		
	}
	
}


	


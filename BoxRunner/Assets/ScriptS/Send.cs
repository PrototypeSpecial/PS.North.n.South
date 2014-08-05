using UnityEngine;
using System.Collections;

public class Send : MonoBehaviour {

    public GameObject Target;
    public string MethodName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        Target.SendMessage(MethodName);
    }
}

#pragma strict
// 20140720 ejlee 커밋 & 푸쉬 테스트

private var box:GameObject;
private var moveSpeed:float = 10.0f;


function Start () {
	// 씬에 있는거 
	box = GameObject.Find("Cube");
}

// 20140720 ejlee 버튼 
function OnGUI()
{
	// Left
	if(GUI.RepeatButton(Rect(10,270,50,30),"<"))
	{
		if( box.transform.position.x < -10 )
		{
			box.transform.position.x = 10;
		}
		box.transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
	}
		
	// Right
	if(GUI.RepeatButton(Rect(100,270,50,30),">"))
	{
		if( box.transform.position.x > 10 )
		{
			box.transform.position.x = -10;
		}	
		box.transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
	}
	
	// Fire
	if(GUI.Button(Rect(170,270,50,30),"^"))
	{
		// 동적 생성
		var sphere : GameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = box.transform.position;
		sphere.transform.localScale = Vector3(0.3, 0.3, 0.3);
		
		sphere.AddComponent("BulletScript");
	}	
	
}

function Update () {

}
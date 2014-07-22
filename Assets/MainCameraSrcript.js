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
	if(GUI.RepeatButton(Rect(10,470,150,130),"<"))
	{
		if( box.transform.position.x < -10 )
		{
			box.transform.position.x = 10;
		}
		box.transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
	}
		
	// Right
	if(GUI.RepeatButton(Rect(200,470,150,130),">"))
	{
		if( box.transform.position.x > 10 )
		{
			box.transform.position.x = -10;
		}	
		box.transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
	}
	
	// Fire
	if(GUI.Button(Rect(470,470,150,130),"^"))
	{
		// 동적 생성
		var sphere : GameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = box.transform.position;
		sphere.transform.localScale = Vector3(0.3, 0.3, 0.3);
		
		var sc : SphereCollider;
		sphere.AddComponent("BulletScript");
		sc = sphere.AddComponent(SphereCollider);
		sc.center = Vector3(0,0,0);
		sc.radius = 0.5;
		sc.isTrigger = true;
		
		var rb : Rigidbody;
		rb = sphere.AddComponent(Rigidbody);
		rb.useGravity = false;
	}	
	
}

function Update () {

}
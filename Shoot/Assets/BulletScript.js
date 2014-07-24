#pragma strict

private var Speed:float = 3.0f;

function Start () {

}

function Update () {
	this.transform.Translate(Vector3.up* Speed* Time.deltaTime);
	if(	this.transform.position.y > 10 )
	{
		Destroy(this.gameObject);
	}
}

function OnTriggerEnter (other : Collider) 
{
	Destroy(this.gameObject);
}
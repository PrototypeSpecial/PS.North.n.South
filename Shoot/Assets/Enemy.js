#pragma strict

private var Health:int = 5;

function Start () {

}

function Update () {

}


function OnTriggerEnter (other : Collider) 
{
	Destroy(this.gameObject);
}
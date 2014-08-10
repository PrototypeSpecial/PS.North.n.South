using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float Speed = 30f;
	public float Power = 12f;
	public float Life = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Life -= Time.deltaTime;
		if (Life <= 0f) 
		{
			Destroy (this.gameObject);
		}

		transform.Translate (Vector3.forward * Speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        if( collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            
            if( enemy.ES != EnemyState.Die)
            {
                enemy.Hurt(Power);
            }
        }
    }
}

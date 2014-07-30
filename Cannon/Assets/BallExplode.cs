using UnityEngine;
using System.Collections;

public class BallExplode : MonoBehaviour {
    public float timeToLiveSec = 5f;
    public float radius = 5f;
    public float explosionForce = 1000f;
    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.realtimeSinceStartup;
	}
	
    void FixedUpdate()
    {
        if ((Time.realtimeSinceStartup - startTime) > timeToLiveSec)
            Explode();
    }

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in colliders)
        {
            if(!col.gameObject.Equals(gameObject) && col.rigidbody != null)
            {
                col.rigidbody.AddExplosionForce(explosionForce, transform.position, radius, 5f);
            }
        }
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}
}

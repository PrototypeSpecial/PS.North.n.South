using UnityEngine;
using System.Collections;

public class HealPoint : MonoBehaviour {
    public float healthPoint = 100f;

    void OnCollisionEnter(Collision collision)
    {
        healthPoint -= collision.impactForceSum.sqrMagnitude;

        if (healthPoint <= 0)
            Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

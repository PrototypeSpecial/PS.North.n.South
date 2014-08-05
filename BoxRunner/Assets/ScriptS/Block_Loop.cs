using UnityEngine;
using System.Collections;

public class Block_Loop : MonoBehaviour {

    public float speed = 3;
    public GameObject[] Block;
    public GameObject A_Zone;
    public GameObject B_Zone;

    void Move()
    {
        A_Zone.transform.Translate(Vector3.left * speed * Time.deltaTime);
        B_Zone.transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(B_Zone.transform.position.x<=0)
        {
            Destroy(A_Zone);
            A_Zone = B_Zone;
            Make();
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    void Make()
    {
        int A = Random.Range(0, Block.Length);

        B_Zone = Instantiate(Block[A], new Vector3(A_Zone.transform.position.x+30, -5, 0), transform.rotation) as GameObject;
    }
}

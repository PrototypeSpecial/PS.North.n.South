using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Attack,
    Dead,
}

public class Player_Ctrl : MonoBehaviour {

    public PlayerState PS;

    public Vector3 lookDirection;
    public float Speed = 0f;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;

    Animation animation;
    public AnimationClip Idle_Ani;
    public AnimationClip Walk_Ani;
    public AnimationClip Run_Ani;

	public GameObject Bullet;
	public Transform ShotPoint;
	public GameObject ShotFX;
	public AudioClip ShotSound;

    void KeyboardInput()
    {
        float xx = Input.GetAxisRaw("Vertical");
        float zz = Input.GetAxisRaw("Horizontal");

        if( Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)||
            Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow))
        {
            lookDirection = xx * Vector3.forward + zz * Vector3.right;
            Speed = WalkSpeed;
            PS = PlayerState.Walk;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
            {
                Speed = RunSpeed;
                PS = PlayerState.Run;
            }
        }

        if(xx==0 && zz==0 && PS != PlayerState.Idle)
        {
            PS=PlayerState.Idle;
            Speed=0f;
        }
    }

    void LookUpdate()
    {
        Quaternion R = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 10f);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
	// Use this for initialization
	void Start () {
        animation = this.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        KeyboardInput();
        LookUpdate();
        AnimationUpdate();
	}

    void AnimationUpdate()
    {
        if(PS==PlayerState.Idle)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
        else if (PS == PlayerState.Walk)
        {
            animation.CrossFade(Walk_Ani.name, 0.2f);
        }
        else if (PS == PlayerState.Attack)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
        else if (PS == PlayerState.Dead)
        {
            animation.CrossFade(Idle_Ani.name, 0.2f);
        }
    }
}

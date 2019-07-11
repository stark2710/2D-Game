using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerControl : MonoBehaviour {

	public float speed = 5f;
	private float movement = 1f;
	public float jumpSpeed = 8f;
	private Rigidbody2D rigidbody;
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isTouchingGround;
	private Animator playerAnimation;
	public Vector3 respwanPoint;
	public LevelManager gameLevelManager;
	public GameObject Fall;
	float drix;
	float Direc;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		playerAnimation = GetComponent<Animator>();
		respwanPoint = transform.position;
		gameLevelManager = FindObjectOfType<LevelManager>();
		Direc = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
	//	movement = Input.GetAxis("Horizontal");
	 //   Debug.Log (movement);
		drix = CrossPlatformInputManager.GetAxis("Horizontal");
			if(drix>0){
			rigidbody.velocity = new Vector2 (drix*speed, rigidbody.velocity.y);
	 		transform.localScale = new Vector2 (3.949742f, 3.949742f);		
	 }
    else if(drix < 0){
	 	rigidbody.velocity = new Vector2 (drix*speed, rigidbody.velocity.y);
	 	transform.localScale = new Vector2 (-3.949742f, 3.949742f);
	 }
	 if(Input.GetButtonDown("Jump") && isTouchingGround){
	 	rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed );
	 }
	 playerAnimation.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
	 playerAnimation.SetBool("onGround", isTouchingGround);
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="FallDetector"){
			Debug.Log ("Entered");
			gameLevelManager.Respwan();
		}
		//if(other.gameObject == Fall){
		//	Debug.Log ("Entered");
		//	gameLevelManager.Respwan();
		//}
		if(other.tag == "CheckPoint"){
			respwanPoint = other.transform.position;
		}
	}

	public void jump(){
		isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
		if (isTouchingGround) {
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed );
		}
	}
		
	public void forward(){
		Direc = 1f;
		rigidbody.velocity = new Vector2 (Direc*speed, rigidbody.velocity.y);
		transform.localScale = new Vector2 (3.949742f, 3.949742f);
	}
	public void backward(){
		Direc = -1f;
		rigidbody.velocity = new Vector2 (Direc*speed, rigidbody.velocity.y);
		transform.localScale = new Vector2 (-3.949742f, 3.949742f);
	}
}
// && isTouchingGround
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public float speed = 5f;
	private float movement = 1f;
	public float jumpSpeed = 8f;
	private Rigidbody2D rigidbody;
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isTouchingGround;
	
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
		movement = Input.GetAxis("Horizontal");
	 //   Debug.Log (movement);
	 if(movement > 0){
		rigidbody.velocity = new Vector2 (movement*speed, rigidbody.velocity.y);
	 }
	 else if(movement < 0){
	 	rigidbody.velocity = new Vector2 (movement*speed, rigidbody.velocity.y);
	 }
	 if(Input.GetButtonDown("Jump") && isTouchingGround){
	 	rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed );
	 }

	}
}

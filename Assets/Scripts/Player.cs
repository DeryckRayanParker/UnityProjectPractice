﻿using UnityEngine;
using System.Collections;

public class Player: MonoBehaviour {

	public float maxspeed = 5f;
	public float jumpForce = 4f;
	public bool jump = false;
	float jumpTime = 0f;
	float maxJumpTime = 0.8f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	[HideInInspector]
	public bool lookingRight = true;

	private Rigidbody2D rb2d;
	private Animator anim;
	public bool grounded = true;
	public float spawnX;
	public float spawnY;
	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
		spawnX = transform.position.x;
		spawnY = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
			grounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);
			
	}


	void FixedUpdate()
	{
		float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("speed", Mathf.Abs (hor));
		anim.SetBool("grounded", grounded);

		rb2d.velocity = new Vector2(hor * maxspeed, rb2d.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			jump = true;
		}
		if (Input.GetKey (KeyCode.Space) && jump) {
				jumpTime += Time.deltaTime;
			if (jumpTime < maxJumpTime) {
				Vector2 up = rb2d.velocity;
				up.y = jumpForce * (1.2f - jumpTime / maxJumpTime);
				rb2d.velocity = up;
			}
		} else {
			jump = false;
			jumpTime = 0;
		}
		if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
			Flip ();
	}

	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Orc-1" || col.gameObject.name == "OffGround") {
			transform.position = new Vector3 (spawnX, spawnY, transform.position.z);
		}
	
	}
} 
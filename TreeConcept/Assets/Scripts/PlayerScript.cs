using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;
	[HideInInspector]
	public bool jump = false;
	[HideInInspector]
	public static bool Grounded = true;

	Animator anim;
	Rigidbody2D rb2d;

	public float maxSpeed = 1f;
	public float moveForce = 25f;
	public float jumpForce = 1000f;



	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{// we only cast layer on ground layer
		//var grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));      // check if he hit anything
		if (Input.GetButtonDown("Jump") && Grounded)// && Grounded)     // we maling sure we can not double jump in the air
		{
			jump = true;
			Grounded = false;
			//flag = true;
		}

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");  //get our horitzntal axis
		anim.SetFloat("Speed", Mathf.Abs(h));   // set the speed, we have to make sure we dont have negative sped

		if (h * rb2d.velocity.x < maxSpeed) // check if we below our speed limit
		{
			rb2d.AddForce(Vector2.right * h * moveForce); // speeding up in left or right direction
		}

		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)    // check if we are going to fast
		{
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y); // figures out if velocity is positive or neg and
																								  // then figures out what direction we moving to and set the speed to max speed in that direction
		}

		if (h > 0 && !facingRight) { Flip(); }  //moving to the right and we re not facing to the right then flip sprite
		else if (h < 0 && facingRight) { Flip(); }  // same thing

		if (jump)
		{
			anim.SetTrigger("Jump"); // boost the jump and play the animation - jump state
			rb2d.AddForce(new Vector2(0f, jumpForce)); // 0 on x and jump on y axis
			jump = false;   // can not douple jump
		}
	}

	void Flip() // flip our sprite around - if we move right sprite facing right vice versa
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;    //change the direction of sprite
		transform.localScale = theScale;
	}
}

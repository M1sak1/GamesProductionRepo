using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//https://youtu.be/K1xZ-rycYY8 - Player Movement
public class Player_Movement2 : MonoBehaviour
{
    public bool moveable = true;
	private float horizontal;
	private float vertical;
    public float Speed = 8f;
    public float jumpingPower = 6f;
    private bool isFacingRight = true;
	//wallsliding mgmt
    private bool isWallsliding = false;
    public float wallslidingSpeed = 2f;
	//walljumping mgmt
	private bool isWallJumping = false;
	public float wallJumpDriection = 0.2f;
	public float counterWallJump = 4;
	public float wallJumpDuration = 0.4f;
	public Vector2 wallJumpingPower = new Vector2 (8f, 16f);




    [SerializeField] private Rigidbody2D rb; //Player Rigidbody
    [SerializeField] private Transform groundCheck; //PlayersSubObject at feet's Current location
    [SerializeField] private LayerMask groundLayer; //Detecting a layer of the object they are currently on
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>(); //used for the animations
    }
    // Update is called once per frame
    void Update()
    { 
        // Debug.Log(isWallsliding);   fuck it idk why you can wall jump tech its not saying your sliding while in mid air so idk  guess its a feature
         //gets the raw input of the horizontal input axis (a -1 , d 1)
        horizontal = Input.GetAxisRaw("Horizontal");
		vertical = rb.velocity.y;
        if(moveable == false)
        {
            horizontal = 0;
        }

        bool Moving = mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Moving");
        if (horizontal == 0)
        {
            mAnimator.SetBool("Moving", false);
        }
        else if (horizontal != 0)
        {
            mAnimator.SetBool("Moving", true);
        }
        //How the player jumps 
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //takes the rigidbodys velocity and changes it based on the current velocity and the paramater jumping power 
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        //to create a smaller jump if the button is released 
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            //as this is meant to decrease the jumping power its timed by a half
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetButtonDown("Fire1")){
            mAnimator.SetBool("isDashing", true);
        }
		if (Input.GetButtonUp("Fire1"))
		{
			mAnimator.SetBool("isDashing", false);
		}
		if (!isWallJumping)
        {
            Flip();
        }

        WallSlide(); //checks if wallsliding
        WallJump(); //allows for walljumping
    }
    //Runs every time something changes not on every frame
    void FixedUpdate()
    {
		if(!isWallJumping){
			rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
		}
    }
    //Used to flip the players sprite when moving left or right
    private void Flip()
    {
        //disabling walljumping when the player moves off the wall
        mAnimator.SetBool("walled", false);
        isWallJumping = false;
        //checks if they have changed their movement and need to be flipped
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight; //flips the variable 
            Vector3 localScale = transform.localScale; //idk
            localScale.x *= -1f; //idk
            transform.localScale = localScale; //idk
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if(IsWalled() && vertical < 0f)
        {
			mAnimator.SetBool("walled", true);
			isWallsliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallslidingSpeed, float.MaxValue));
        }
        else
        {
			mAnimator.SetBool("walled", false); 
			isWallsliding = false;
        }
    }

	private void WallJump(){
		//checking if it is possible
		if(isWallsliding){
			isWallJumping = false;
			wallJumpDriection = -transform.localScale.x;
			counterWallJump = wallJumpDuration;
			CancelInvoke(nameof(StopWallJumping));
		}
		else {
			counterWallJump -= Time.deltaTime;
		}
		
		//acutally jumping
		if(Input.GetButtonDown("Jump") && counterWallJump > 0f) { 
			isWallJumping = true;
			rb.velocity = new Vector2(wallJumpDriection * wallJumpingPower.x, wallJumpingPower.y);
			counterWallJump = 0f;
			////flipping the player
			if (transform.localScale.x != wallJumpDriection)
			{
				isFacingRight = !isFacingRight;
				Vector3 localscale = transform.localScale;
				localscale.x *= -1f;
				transform.localScale = localscale;
			}
		}
		//Flip();

		Invoke(nameof(StopWallJumping), wallJumpDuration); // calls the stop walljumping after a delay (walljumpduration)
	}

	private void StopWallJumping(){
		isWallJumping = false;
	}

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

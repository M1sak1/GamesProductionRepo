using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//https://youtu.be/K1xZ-rycYY8 - Player Movement
public class Player_Movement2 : MonoBehaviour
{
    //HAHA this looks so stupid but necessary 
    public bool moveable = true;
	private float horizontal;
    public float Speed = 8f;
    public float jumpingPower = 6f;
    private bool isFacingRight = true;
    public float gravity = 3f;
    public bool isFalling = false;
	//wallsliding mgmt
    private bool isWallsliding = false;
    public float wallslidingSpeed = 2f;
	//walljumping mgmt
	private bool isWallJumping = false;
	public float wallJumpDriection = 0.2f;
	public float counterWallJump = 4;
	public float wallJumpDuration = 0.4f;
	public Vector2 wallJumpingPower = new Vector2 (8f, 16f);
    //Dashing
    public float DashPower = 10;
    public float DashDuration = 0.5f;
    public bool isDashing = false;
    public int DashCounter = 1;
    public int maxDashes;



    [SerializeField] private Rigidbody2D rb; //Player Rigidbody
    [SerializeField] private Transform groundCheck; //PlayersSubObject at feet's Current location
    [SerializeField] private LayerMask groundLayer; //Detecting a layer of the object they are currently on
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private Animator mAnimator;
    private SpriteRenderer mSpriteRend;

    private void Start()
    {
        maxDashes = DashCounter;    //setting the maximum amount of dashes per jump for the player
		mAnimator = GetComponent<Animator>(); //used for the animations
        mSpriteRend = GetComponent<SpriteRenderer>(); //only touch this in verry spesific cases. !!!
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isWallsliding);   fuck it idk why you can wall jump tech its not saying your sliding while in mid air so idk  guess its a feature
        //gets the raw input of the horizontal input axis (a -1 , d 1)       
        horizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log(rb.velocity.y);
        if (!IsGrounded() && !isWallsliding && !isDashing && rb.velocity.y < 0 && !isFalling)
        {
            isFalling = true;
			mAnimator.SetBool("isFalling", true);
		}
        else
        {
            if (isFalling && IsGrounded() || isFalling && IsWalled())
            {
                isFalling = false;
                mAnimator.SetBool("isFalling", false);
            }
        }
        if(moveable == false)
        {
            horizontal = 0;
        }

        //maintaining Dashes
        if (IsGrounded() )
        {
            DashCounter = maxDashes;
        }
        bool Moving = mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Moving");
        if (horizontal == 0 && !isDashing)
        {
            mAnimator.SetBool("Moving", false);
        }
        else if (horizontal != 0 && !isDashing)
        {
            mAnimator.SetBool("Moving", true);
        }
        //How the player jumps 
        if (Input.GetButtonDown("Jump") && IsGrounded() && !isDashing)
        {
            //takes the rigidbodys velocity and changes it based on the current velocity and the paramater jumping power 
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        //to create a smaller jump if the button is released 
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && !isDashing)
        {
            //as this is meant to decrease the jumping power its timed by a half
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetButtonDown("Fire1") && !isDashing && DashCounter > 0)
		{
            DashCounter--;
            DashPrime();
        }
		if (!isWallJumping && !isWallsliding && !isDashing)
        {
            Flip();
        }
        WallSlide(); //checks if wallsliding
        WallJump(); //allows for walljumping
    }
    //Runs every time something changes not on every frame
    void FixedUpdate()
    {
		if(!isWallJumping && !isDashing){
			rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
		}
    }
    //Used to flip the players sprite when moving left or right
    private void Flip()
    {
        //checks if they have changed their movement and need to be flipped
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight;
            //physically flips the sprite
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    //dangerious 

	private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if(IsWalled() && !IsGrounded() && horizontal !=0f)
        {
            
		   //wallsiding
			mAnimator.SetBool("walled", true);
			isWallsliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallslidingSpeed, float.MaxValue));
        }
        else
        {
            if (IsGrounded() && isWallsliding || !IsWalled() && isWallsliding)
            {
				mAnimator.SetBool("walled", false);
                isWallsliding = false;
			}
        }
    }

	private void WallJump(){
        //checking if it is possible
        if (isWallsliding && !isWallJumping){
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
            Debug.Log("jumpDir " + wallJumpDriection + "  " );
			isWallJumping = true;
			rb.velocity = new Vector2( wallJumpDriection * wallJumpingPower.x, wallJumpingPower.y);
			counterWallJump = 0f;
		}

		Invoke(nameof(StopWallJumping), wallJumpDuration); // calls the stop walljumping after a delay (walljumpduration)
	}
	private void StopWallJumping(){
		isWallJumping = false;
	}
	private void DashPrime()
	{
        if (!isDashing)
        {
            var dir = transform.localScale.x;
			isDashing = true;
            mAnimator.SetBool("isDashing", true);
            rb.gravityScale = 0f;
            Debug.Log("Starting a dash");
            rb.velocity = new Vector2(dir * DashPower, 0); // the dash itself
            Invoke(nameof(DashExit), DashDuration + 0.2f);
        }
    }
	private void DashExit()
	{
		rb.gravityScale = gravity;
        Debug.Log("is Dashing Exit");
        //mAnimator.ResetTrigger("isDashing");
		mAnimator.SetBool("isDashing", false);
        rb.velocity = new Vector2(0, 0);
        isDashing = false;
	}

	private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement2 : MonoBehaviour
{
    public float horizontal;
    public float Speed = 8f;
    public float jumpingPower = 6f;
    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb; //Player Rigidbody
    [SerializeField] private Transform groundCheck; //PlayersSubObject at feet's Current location
    [SerializeField] private LayerMask groundLayer; //Detecting a layer of the object they are currently on

    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //gets the raw input of the horizontal input axis (a -1 , d 1)
        horizontal = Input.GetAxisRaw("Horizontal");
        bool Moving = mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Moving");
        if (horizontal == 0)
        {
            mAnimator.SetBool("Moving", false); 
        }
        
        else if(horizontal != 0)
        {
            mAnimator.SetBool("Moving", true);
        }
        //How the player jumps 
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            //takes the rigidbodys velocity and changes it based on the current velocity and the paramater jumping power 
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        //to create a smaller jump if the button is released 
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            //as this is meant to decrease the jumping power its timed by a half
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }
    //Runs every time something changes not on every frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }
    //Used to flip the players sprite when moving left or right
    private void Flip()
    {
        //checks if they have changed their movement and need to be flipped
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight; //flips the variable 
            Vector3 localScale = transform.localScale; //idk
            localScale.x *= -1f; //idk
            transform.localScale = localScale; //idk
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

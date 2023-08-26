/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool onPlatform = false;

    // Update is called once per frame
    void Update()
    {

       PlayerMove ();       // calls the movement [working], includes the phasing through ground feature [no working]
        if (Input.GetKeyUp(KeyCode.DownArrow) && onPlatform == true && isGrounded == false)
        {
           gameObject.GetComponent<Collider2D>().enabled = false;
        }
           
    }

    void PlayerMove()
    {
        //controlls
        moveX = Input.GetAxis("Horizontal"); 
        if (Input.GetButtonDown ("Jump") && isGrounded == true || (Input.GetButtonDown("Jump") && onPlatform == true)) //this disallows the player from jumping when their not on a platform or the ground
        {
            jump();
        }
        //aminations
        //playr direction, this flips the players sprite
        if (moveX < 00f && facingRight == false)
        {
            flipPlayer();
        }
        else if (moveX > 00f && facingRight == true)
        {
            flipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); //this is the movement left and right (its a little crude but it works)
    }

    void jump() //jump system [working]
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void flipPlayer()   //filps the players sprite to which ever way they are walking. [working]
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnCollisionEnter2D(Collision2D col)    //updating tags, for the phasing through ground mechanic [currently not working]
    {
        Debug.Log("player on " + col.collider.name);    //this updates the tags on objects
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
            onPlatform = false;
        }
        if (col.gameObject.tag == "platform")
        {
            onPlatform = true;
        }
        if (col.gameObject.tag != "platform")       //basicly saying that if the player os not on a platform, the rigid body will be active.
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
            
    }

}
*/
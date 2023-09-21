using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
	{
	private Animator animator;
	Collider2D player; // used to lock the player when dying 
	[SerializeField] private Rigidbody2D rb; //Player Rigidbody
	[SerializeField]
	Vector3 _startPosition;
	private void Start ()
	{
		animator = GetComponent<Animator>();
	}

	public void Awake()
	{
		GameManager.Instance.SetStartPosition(_startPosition); // to grab a position to reset to when the player dies without touching a checkpoint
	}
	//https://bergstrand-niklas.medium.com/setting-up-a-simple-game-manager-in-unity-24b080e9516c
	public void KillPlayer()
	{ 
		animator.SetBool("isDead", true);
		gameObject.GetComponent<Player_Movement2>().moveable = false; //Stops the players movement while dying 
		Invoke(nameof(murder), 1f);
		
	}
	private void murder()
	{
		gameObject.GetComponent<Player_Movement2>().moveable = true; //gives the player back there movement
		transform.position = GameManager.Instance.StartPosition; //sends the player back to the last updated checkpoint/startpositon 
		animator.SetBool("isDead", false);
	}
	public void playWin()
	{
		animator.SetBool("hasWon", true);	
	}
}


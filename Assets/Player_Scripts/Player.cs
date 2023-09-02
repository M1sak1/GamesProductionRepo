using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
	public class Player : MonoBehaviour
	{
	[SerializeField]
	Vector3 _startPosition;

	public void Awake()
	{
		GameManager.Instance.SetStartPosition(_startPosition); // to grab a position to reset to when the player dies without touching a checkpoint
	}
	//https://bergstrand-niklas.medium.com/setting-up-a-simple-game-manager-in-unity-24b080e9516c
	public void KillPlayer()
		{
			transform.position = GameManager.Instance.StartPosition; //sends the player back to the last updated checkpoint/startpositon 
		}
	}


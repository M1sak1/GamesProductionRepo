using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	[SerializeField]
	Vector3 _startPosition;
	//https://bergstrand-niklas.medium.com/how-to-add-lives-and-checkpoints-in-unity-eccf68e632a9
	private void OnTriggerEnter2D(Collider2D other) //detects if the player has hit this invisible block and updates the players start position to this point
	{
		if(other.tag == "Player")			 
		{
			GameManager.Instance.SetStartPosition(_startPosition); //setting the start position to a defined position in unity
			Destroy(gameObject); //cant re-checkpoint 
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
	//https://bergstrand-niklas.medium.com/how-to-add-lives-and-checkpoints-in-unity-eccf68e632a9 
	void OnTriggerEnter2D(Collider2D other){ //detects if the player has hit this invisible block and resets the player back to a checkpoint/startposition
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().KillPlayer();
		}
	}
}

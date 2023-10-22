using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_fancy : MonoBehaviour
{
	public Transform target;
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D other) //detects if the player has hit this invisible block and changes the scene to the winScreen as the player has won 
	{
		target.gameObject.GetComponent<Player_Movement2>().AllowedToDash = true;
	}
}

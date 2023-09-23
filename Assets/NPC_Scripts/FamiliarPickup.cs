using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class FamiliarPickup : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject Familiar;

	void OnTriggerEnter2D(Collider2D other)
	{ //detects if the player has hit this invisible block and resets the player back to a checkpoint/startposition
		if (other.tag == "Player")
		{
			//Sets the script to run using a bool called enable and the function sets to true
			Familiar.GetComponent<FollowPlayer>().SetEnable();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	[SerializeField]
	Vector3 _startPosition;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("???");
		if(other.tag == "Player")			 
		{
			GameManager.Instance.SetStartPosition(_startPosition); //setting the start position to a defined position in unity
			Destroy(gameObject); //cant re-checkpoint 
		}
	}
}

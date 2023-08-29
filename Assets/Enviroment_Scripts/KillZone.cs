using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
	public bool init = false;
    void OnTriggerEnter(Collider other){
		init = !init;
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().KillPlayer();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinTrigger : MonoBehaviour
{

	//https://bergstrand-niklas.medium.com/how-to-add-lives-and-checkpoints-in-unity-eccf68e632a9
	private void OnTriggerEnter2D(Collider2D other) //detects if the player has hit this invisible block and changes the scene to the winScreen as the player has won 
	{
		other.gameObject.GetComponent<Player_Movement2>().moveable = false;
		other.gameObject.GetComponent<Player>().playWin();
		Invoke(nameof(finishwnig), 0.6f);
	}
	private void finishwnig()
	{
		SceneManager.LoadScene("WinScreen");
	}
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
	public Animator animator;
	Collider2D player;

    //https://bergstrand-niklas.medium.com/how-to-add-lives-and-checkpoints-in-unity-eccf68e632a9
    private void OnTriggerEnter2D(Collider2D other) //detects if the player has hit this invisible block and changes the scene to the winScreen as the player has won 
	{
		int CurrentLevel = SceneManager.GetActiveScene().buildIndex + 1;
		player = other;
		other.gameObject.GetComponent<Player_Movement2>().moveable = false;
		other.gameObject.GetComponent<Player>().playWin();
        animator.SetTrigger("FadeOut");
        Invoke(nameof(finishwin), 0.6f);
	}
    //Fade stuff and mading this code re-usable https://www.youtube.com/watch?v=Oadq-IrOazg&ab_channel=Brackeys
	private void finishwin()
	{
        int NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(NextLevel);
	}
}
 
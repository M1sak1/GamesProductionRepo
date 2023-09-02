using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//https://bergstrand-niklas.medium.com/setting-up-a-simple-game-manager-in-unity-24b080e9516c
	#region Singleton
	private static GameManager _instance;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("GameManager is NULL");
			}
			return _instance;
		}
		
	}
	
	private void Awake()
	{
		if (_instance)
			Destroy(gameObject);
		else
			_instance = this;

		DontDestroyOnLoad(this);
	}
	#endregion //forces one instance of the game 

	public int hasPowerUp { get; set; } //Used to track things throughout the game 

	public Vector3 StartPosition { get; private  set; }
	//Used for checkpointing and position loging 
	
	public void SetStartPosition(Vector3 position){
		StartPosition = position;
	}
	/*
	public void KillPlayer(){
		transform.position = GameManager.Instance.StartPosition;
	}
	*/

}
							
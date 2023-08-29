using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class Player : MonoBehaviour
	{
	[SerializeField]
	Vector3 _startPosition;

	public void Awake()
	{
		GameManager.Instance.SetStartPosition(_startPosition);
	}
	public void KillPlayer()
		{
			transform.position = GameManager.Instance.StartPosition;
		}
	}


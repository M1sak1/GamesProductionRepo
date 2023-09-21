using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform target;
	public Vector3 offset; //how far it will stay away from the target
	[Range(1, 10)]
	public float SmoothFactor;
    // Update is called once per frame
    void FixedUpdate()
    {
		Follow();
	}

	void Follow()
	{
		Vector3 targetPosition = target.position + offset;
		Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, SmoothFactor*Time.fixedDeltaTime);
		transform.position = targetPosition;
	}
}

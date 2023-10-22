using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/Packages/com.unity.ai.navigation@1.1/manual/index.html
public class FollowPlayer : MonoBehaviour
{
	public bool Enable = false;
	public Transform target;
	public Vector3 offset; //how far it will stay away from the target
	[Range(1, 200)]
	public float SmoothFactor;

    // Update is called once per frame
    void Update()
    {
		if (Enable)
        {
			Follow();
		}
        
	}

	void Follow()
	{
		//https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
		if (target.gameObject.GetComponent<Player_Movement2>().isFacingRight)
		{
			Debug.Log("Detecting rightness");
			if (offset.x < 0)
			{
				offset.x = -offset.x;
			}
		}
        if (!target.gameObject.GetComponent<Player_Movement2>().isFacingRight)
        {
            Debug.Log("Detecting non-rightness");
            if (offset.x > 0)
            {
                offset.x = -offset.x;
            }
        }
        Vector3 targetPosition = target.position + offset;
		Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, SmoothFactor * Time.fixedDeltaTime * 0.2f);
		transform.position = smoothPosition;
		//Debug.Log(targetPosition);
        //Debug.Log(smoothPosition);
    }

	public void SetEnable()
	{
		Enable = true;
	}
}

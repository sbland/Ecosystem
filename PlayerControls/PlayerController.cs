using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Controls controls;
	float smoothing = 0.1f;

	// Use this for initialization
	void Start ()
	{
		controls = GetComponent<Controls> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Input.GetKey (controls.forward))
			{
			Vector3 target = new Vector3(0,0,100f);
			Vector3 move = Vector3.Lerp(rigidbody.position, rigidbody.position + target, Time.deltaTime * smoothing);
			rigidbody.MovePosition(move);
			}

		if(Input.GetKey (controls.backwards))
		   {
			Vector3 target = new Vector3(0,0,100f);
			Vector3 move = Vector3.Lerp(rigidbody.position, rigidbody.position - target, Time.deltaTime * smoothing);
			rigidbody.MovePosition(move);
			}

		if(Input.GetKey (controls.strafeLeft))
		{
			Vector3 target = new Vector3(100f,0,0);
			Vector3 move = Vector3.Lerp(rigidbody.position, rigidbody.position - target, Time.deltaTime * smoothing);
			rigidbody.MovePosition(move);
		}

		if(Input.GetKey (controls.strafeRight))
		{
			Vector3 target = new Vector3(100f,0,0);
			Vector3 move = Vector3.Lerp(rigidbody.position, rigidbody.position + target, Time.deltaTime * smoothing);
			rigidbody.MovePosition(move);
		}


	}

}


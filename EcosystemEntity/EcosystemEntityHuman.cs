using UnityEngine;
using System.Collections;

public class EcosystemEntityHuman : EcosystemEntity
{
	Vector3 target;
	bool nearFood = false; 

	void OnTriggerEnter (Collider active)
	{
		float smoothing = 1f;

		if (active.GetComponent ("EcosystemEntity") != null) {

			EcosystemEntity hitObject = active.GetComponent<EcosystemEntity>();
			if(hitObject.entityName == "Cow")
			{
				nearFood = true;
				Debug.Log ("Entered");
				target = active.rigidbody.position;
				Vector3 move = Vector3.Lerp(rigidbody.position, target, Time.deltaTime * smoothing);
				rigidbody.MovePosition(move);
			}

		}
	}

	void OnTriggerExit (Collider active)
	{
		nearFood = false;
	}

	void Update () {
		UpdateExtra ();
	}

	new void UpdateExtra ()
	{
		if(nearFood)
		{
			//Vector3 target = new Vector3(0,0,100f);
			Vector3 move = Vector3.Lerp(rigidbody.position, target, Time.deltaTime * 1f);
			rigidbody.MovePosition(move);
		}
	}
}


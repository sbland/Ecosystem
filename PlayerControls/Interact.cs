using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Keypad0)) {
			EcosystemEntityTree tree = new EcosystemEntityTree();
			tree.Create();
				}
		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			EcosystemEntityHuman human = new EcosystemEntityHuman();
			human.Create();
		}
		if (Input.GetKeyDown (KeyCode.Keypad2)) {
			EcosystemEntityCow cow = new EcosystemEntityCow();
			cow.Create();
		}
	}

	void OnTriggerEnter (Collider active)
	{
		GUISetup.labelTest = "Press [Del] to remove " + active.name;
		active.renderer.material.color = Color.green;
	}

	void OnTriggerStay (Collider active)
	{
		if(Input.GetKeyDown(KeyCode.Delete))
		{
			EcosystemEntityTree tree = new EcosystemEntityTree();
			EcosystemEntityHuman human = new EcosystemEntityHuman();
			EcosystemEntityCow cow = new EcosystemEntityCow();

			Debug.Log(active.tag);

			switch (active.tag)
			{
				case "ecosystemTrees":
				{
					tree.Remove(active);
					break;
				}

				case "ecosystemCow":
				{
					cow.Remove(active);
					break;
				}

				case "ecosystemHuman":
				{
					human.Remove(active);
					break;
				}

				default:
				{
					break;
				}
			}

			//Destroy(active);
			active.renderer.material.color = Color.red;
		}
	}

	void OnTriggerExit (Collider active)
	{
		GUISetup.labelTest = "";
		active.renderer.material.color = Color.grey;
	}
}
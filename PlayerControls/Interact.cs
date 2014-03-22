/*************************************************************************
  Interact Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Controls user interaction

 ------------------------------------------------------------------------
  History:30/12/13 - Transfered to C#

 ------------------------------------------------------------------------
 Contents
	1.	Imports
	2.	Variables
		2.1.
	3.	Standard Functions
		3.1. 	
	4.	Unique Functions
		4.1.	
	5.	Debug functions
		5.1.	


*************************************************************************/

using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {


	
	public Inventory inventory;
	public Controls controls;


	// Use this for initialization
	void Start () {
		inventory = new Inventory();
		controls = GetComponent<Controls> ();
	}
	
	// Update is called once per frame
	void Update () {
	/*
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
*/

		if (Input.GetKeyDown (controls.drop)) {
			inventory.removeItem();
		}
		
	}

	void OnTriggerEnter (Collider active)
	{
		GUISetup.response = "Press [Del] to remove " + active.tag;
		//active.renderer.material.color = Color.green;
	}

	void OnTriggerStay (Collider active)
	{

		if(Input.GetKey(KeyCode.Delete))
		{

			if(active.GetComponent("EcosystemEntity") != null)
			{
				EcosystemEntity hitObject = active.GetComponent<EcosystemEntity>();
				Debug.Log("removing " + hitObject.entityName);
				hitObject.Remove();
			}

			//Destroy(active);

			//active.renderer.material.color = Color.red;
		}


		if (Input.GetKeyDown (controls.use)) {
			Debug.Log("Adding " + active.name + " to the inventory");
			inventory.addItem(active.gameObject);	
				}


	}

	void OnTriggerExit (Collider active)
	{
		GUISetup.response = "";
		//active.renderer.material.color = Color.grey;
	}
}
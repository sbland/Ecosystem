/*************************************************************************
  Inventory Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Controls inventory system

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
using System.Collections.Generic;

public class Inventory// : MonoBehaviour
{
	//
	public static int bagSize = 10;
	public static int itemCount = 0;

	public static List <GameObject> bag = new List<GameObject>();

	private GameObject spawnPlane = GameObject.Find("SpawnPlane");
	private GameObject inventoryBox = GameObject.Find("Inventory");



	public bool addItem(GameObject item)
	{
		if (itemCount < bagSize) {
			bag.Add (item);
			itemCount ++;
			item.rigidbody.position = inventoryBox.rigidbody.position;
			Debug.Log(item.name + " added!");
			return true;
		} else {
			Debug.Log("Bag full!");
			return false;
		}
			
	}

	public bool removeItem()
	{
		//remove item from bag
		//instantiate the item infront of the player;

		GameObject player = GameObject.Find("Pointer");	
		//GameObject item = GameObject.Find ("Cleet");
		//int slot = bag.IndexOf (item);
		bag [0].rigidbody.position = player.rigidbody.position;
		//bag.RemoveAt (slot);
		return true;
	}
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory// : MonoBehaviour
{

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
		GameObject item = GameObject.Find ("Cleet");
		int slot = bag.IndexOf (item);
		Debug.Log (slot);
		bag.RemoveAt (slot);
		bag [slot].rigidbody.position = player.rigidbody.position;
	
		//Rigidbody newInstance;

		//newInstance = MonoBehaviour.Instantiate (bag[0], player.rigidbody.position, player.rigidbody.rotation) as Rigidbody;
		return true;
	}
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory// : MonoBehaviour
{

	public static int bagSize = 10;
	public static int itemCount = 0;

	public static List <GameObject> bag = new List<GameObject>();

	private GameObject spawnPlane = GameObject.Find("SpawnPlane");



	public bool addItem(GameObject item)
	{
		if (itemCount < bagSize) {
			bag.Add (item);
			itemCount ++;
			Debug.Log(item.name + " added!");
			return true;
		} else {
			Debug.Log("Bag full!");
			return false;
		}

	}

	public bool removeItem(GameObject item)
	{
		//remove item from bag
		//instantiate the item infront of the player;

		bag.Remove (item);
		GameObject player = GameObject.Find("Pointer");

		Rigidbody newInstance;

		newInstance = MonoBehaviour.Instantiate (item, player.rigidbody.position, player.rigidbody.rotation) as Rigidbody;
		return true;
	}
}


using UnityEngine;
using System.Collections;

public class GUISetup : MonoBehaviour {

	public static string response = "";
	void OnGUI ()
	{
		//GUI.Box (new Rect (100, 100, 200, 200), labelTest);
		GUI.Label (new Rect (100, 100, 400, 400), Ecosystem.atmosphere.Oxygen + EcosystemAtmosphere.Units.Oxygen);
		GUI.Label (new Rect (100, 200, 400, 400), Ecosystem.atmosphere.Co + EcosystemAtmosphere.Units.Co);
		GUI.Label (new Rect (300, 100, 400, 400), EcosystemEntityData.Humans.count + " Humans");
		GUI.Label (new Rect (300, 200, 400, 400), EcosystemEntity.cowCount + " Cows");
		GUI.Label (new Rect (300, 300, 400, 400), EcosystemEntity.treeCount + " Trees");
		GUI.Label (new Rect (300, 300, 400, 400), response);
	}

}

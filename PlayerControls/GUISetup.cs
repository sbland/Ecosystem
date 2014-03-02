using UnityEngine;
using System.Collections;

public class GUISetup : MonoBehaviour {

	public static string labelTest = "Test";

	void OnGUI ()
	{
		//GUI.Box (new Rect (100, 100, 200, 200), labelTest);
		GUI.Label (new Rect (100, 100, 400, 400), EcosystemAtmosphere.Oxygen + EcosystemAtmosphere.Units.Oxygen);
		GUI.Label (new Rect (100, 200, 400, 400), EcosystemAtmosphere.Co + EcosystemAtmosphere.Units.Co);
		GUI.Label (new Rect (200, 100, 400, 400), EcosystemEntityCow.Count + " Cows");
		GUI.Label (new Rect (200, 200, 400, 400), EcosystemEntityHuman.Count + " Humans");
		GUI.Label (new Rect (200, 300, 400, 400), EcosystemEntityTree.Count + " Trees");
		GUI.Label (new Rect (600, 600, 400, 400), labelTest);


	}

}

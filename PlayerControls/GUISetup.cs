using UnityEngine;
using System.Collections;

public class GUISetup : MonoBehaviour {

	public static string response = "";
	void OnGUI ()
	{
		EcoStats ();
		UI ();
		DeveloperTools ();
	}

	void EcoStats()
	{
		int i = 0;
		foreach (var item in EcosystemEntityData.entityDictionary) {
			int positionY = (i * 100) + 100;
			string labelText = item.Value.Count + " " + item.Key;
			GUI.Label (new Rect (300, positionY, 400, 400), labelText);
			i++;
				}

		GUI.Label (new Rect (100, 100, 400, 400), Ecosystem.atmosphere.Oxygen + EcosystemAtmosphere.Units.Oxygen);
		GUI.Label (new Rect (100, 200, 400, 400), Ecosystem.atmosphere.Co + EcosystemAtmosphere.Units.Co);

	}

	void UI()
	{
		GUI.Label (new Rect (300, 300, 400, 400), response);
	}

	void DeveloperTools()
	{
		/*if (GUI.Button (new Rect (20, 40, 80, 20), "Test Catalogue")) {
			string result = "";
			for(int i = 0; i<EcosystemEntityData.entityCatalogue.Length; i++)
			{
				result += EcosystemEntityData.entityCatalogue[i] + " ";
			}

			Debug.Log(result);
				}*/
		if (GUI.Button (new Rect (20, 80, 80, 20), "Test Dictionary")) {
			Debug.Log(EcosystemEntityData.entityDictionary["Tree"].Count);
		}
	}

}

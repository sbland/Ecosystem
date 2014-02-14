/*************************************************************************
  Ecosystem Main Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Initializes Ecosystem

 ------------------------------------------------------------------------
  History:30/12/13 - Transfered to C#

Rewriting Ecosystem
*************************************************************************/


using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;



public class Ecosystem : MonoBehaviour {

	//Input
	public int updateRate = 100;

	public double initialOxygen = 10;
	public double initialCo = 20;
	public double initialTemperature = 27;
	public double initialHumidity = 45;

	public Rigidbody treeModel;
	public Rigidbody humanModel;
	public Rigidbody cowModel;
	public Transform spawnPlane;

	public string saveLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Ecosystem";

	//properties

	private int updateCount = 0;
	GameObject[] treeList;
	GameObject[] humanList;
	GameObject[] cowList;
	//objects

	//--------------------------------------------------------------------------------------------------------
	// Use this for initialization2783 4163 7166

	void Start () {
		//set values to user input
		EcosystemAtmosphere.Oxygen = initialOxygen;
		EcosystemAtmosphere.Co = initialCo;
		EcosystemEnvironment.Temperature = initialTemperature;
		EcosystemEnvironment.Humidity = initialHumidity;


		//Allows random trees to be initialized at start
		/*EcosystemEntityTree treeA = new EcosystemEntityTree();
		EcosystemEntityTree treeB = new EcosystemEntityTree();
		EcosystemEntityTree treeC = new EcosystemEntityTree();
		EcosystemEntityTree treeD = new EcosystemEntityTree();
		EcosystemEntityHuman humanA = new EcosystemEntityHuman ();
		EcosystemEntityHuman humanB = new EcosystemEntityHuman ();
		*/


		/*Rigidbody treeInstance;
		Rigidbody humanInstance;

		//create initial trees
		for (int i = 0; i < EcosystemEntityTree.Count; i++) {
			Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 0, Random.Range(-10.0F, 10.0F));
			treeInstance = Instantiate (treeModel, spawnPlane.position+position, spawnPlane.rotation) as Rigidbody;
		}

		//create initial trees
		for (int i = 0; i < EcosystemEntityTree.Count; i++) {
			Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 0, Random.Range(-10.0F, 10.0F));
			humanInstance = Instantiate (humanModel, spawnPlane.position+position, spawnPlane.rotation) as Rigidbody;
		}
		*/
		string dir = saveLocation + "\\saveTest.txt";
		File.WriteAllText (dir, "Trees, Humans, Cow, Oxygen, CO2 \r\n");

	}//End Start()--------------------------------------------------------------------------------------------------------
	
	// Update is called once per frame
	void Update () {

		// Get entity counts
		treeList = GameObject.FindGameObjectsWithTag ("ecosystemTrees");
		humanList = GameObject.FindGameObjectsWithTag ("ecosystemHuman");
		cowList = GameObject.FindGameObjectsWithTag ("ecosystemCow");
		EcosystemEntityTree.Count = treeList.Length;
		EcosystemEntityHuman.Count = humanList.Length;
		EcosystemEntityCow.Count = cowList.Length;

		if (this.updateCount == this.updateRate) 
			{
				EcosystemCalculations();
				EcosystemConsoleLog();
				EcosystemDataLog();
				this.updateCount = 0;
			}
		this.updateCount++;
	

	}//End Update()--------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Ecosystems the calculations.
	/// </summary>
	void EcosystemCalculations()
	{
		EcosystemAtmosphere.Oxygen = EcosystemAtmosphere.Oxygen + ((EcosystemEntityTree.Count * EcosystemEntityTree.OxygenRelease) - (EcosystemEntityHuman.Count * EcosystemEntityHuman.OxygenConsumption)) + 10; 
		EcosystemAtmosphere.Oxygen = EcosystemAtmosphere.Oxygen > 0 ? EcosystemAtmosphere.Oxygen : 0;
		EcosystemAtmosphere.Co = EcosystemAtmosphere.Co + ((EcosystemEntityHuman.Count * EcosystemEntityHuman.coRelease) - (EcosystemEntityTree.Count * EcosystemEntityTree.CoConsumption)) + 10;
		EcosystemAtmosphere.Co = EcosystemAtmosphere.Co > 0 ? EcosystemAtmosphere.Co : 0;

		EcosystemPostCalculations();
	}//End EcosystemCalculations()--------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Ecosystems the post calculations.
	/// </summary>
	void EcosystemPostCalculations()
	{
		Rigidbody treeInstance;
		Rigidbody humanInstance;
		Rigidbody cowInstance;


		//Create Tree
		if (EcosystemAtmosphere.Co > 8) {
			Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
			treeInstance = Instantiate (treeModel, spawnPlane.position + position, spawnPlane.rotation) as Rigidbody;
			EcosystemEntityTree.Count++;
		}

		//Create Human
		if (EcosystemAtmosphere.Oxygen > 8) {
			Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
			humanInstance = Instantiate (humanModel, spawnPlane.position + position, spawnPlane.rotation) as Rigidbody;
			EcosystemEntityHuman.Count++;
		}
		//Create Cow
		if (EcosystemAtmosphere.Oxygen > 15) {
			Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
			cowInstance = Instantiate (cowModel, spawnPlane.position + position, spawnPlane.rotation) as Rigidbody;
			EcosystemEntityCow.Count++;
		}


/*		//Destroy Tree
		if (EcosystemAtmosphere.Co < 2 && treeList.Length > 0) {
			int val = Random.Range(0, treeList.Length-1);

			if(treeList[val]){
		
				try{
					Destroy(treeList[val]);
				}catch(System.Exception e){
					print("Error");
				}
				EcosystemEntityTree.Count --;
			}
		}

		//Destroy Human
		if (EcosystemAtmosphere.Oxygen < 2 && humanList.Length > 0) {
			int val = Random.Range(0, humanList.Length-1);
			if(humanList[val]){
				try{
					Destroy(humanList[val]);
				}catch(System.Exception e){
					print("Error");
				}
				
				EcosystemEntityHuman.Count --;
			}
		}
*/
		//Destroy Cow

		if (EcosystemAtmosphere.Oxygen < 2 && cowList.Length > 0) {
			int val = Random.Range(0, cowList.Length-1);
				if(cowList[val]){
				Destroy(cowList[val]);
				EcosystemEntityCow.Count --;
				}

				
		}


	}// End EcosystemPostCalculations()--------------------------------------------------------------------------------------------------------


	/// <summary>
	/// Ecosystems the console log.
	/// </summary>
	void EcosystemConsoleLog()
	{
		/*
		Debug.Log (EcosystemAtmosphere.Oxygen + EcosystemAtmosphere.Units.Oxygen);
		Debug.Log (EcosystemAtmosphere.Co + EcosystemAtmosphere.Units.Co);
		//Debug.Log (EcosystemEnvironment.Temperature + EcosystemEnvironment.Units.Temperature);
		Debug.Log (EcosystemEntityTree.Count);
		Debug.Log (EcosystemEntityHuman.Count);
		Debug.Log ("End");
		*/
	}// End EcosystemConsoleLog()--------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Ecosystem data Log
	/// -Logs data to an xml file
	/// </summary>
	void EcosystemDataLog()
	{
		//File Write Test]
		string dir = saveLocation + "\\saveTest.txt";
		string[] printme = {EcosystemEntityTree.Count + "", ", " + EcosystemEntityHuman.Count, ", "+ EcosystemEntityCow.Count, ", " + EcosystemAtmosphere.Oxygen, ", " + EcosystemAtmosphere.Co + "\r\n"};
		for (int i = 0; i<printme.Length; i++) 
		{
			File.AppendAllText(dir, printme[i]);
		}

	}// End EcosystemDataLog()--------------------------------------------------------------------------------------------------------
}

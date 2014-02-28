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

	//Input (User)
	public int updateRate = 500;

	public double initialOxygen = 10;
	public double initialCo = 10;
	public double initialTemperature = 27;
	public double initialHumidity = 45;

	public Rigidbody treeModel;
	public Rigidbody humanModel;
	public Rigidbody cowModel;
	public Transform spawnPlane;

	public string saveLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Ecosystem";

	//properties

	public int updateCount = 0;

	GameObject[] humanList;
	GameObject[] cowList;

	string dir;
	//objects


	
	//--------------------------------------------------------------------------------------------------------
	// Use this for initialization

	void Start () {
		Initialization ();
		EntityCounts();

		File.WriteAllText (dir, "Trees, Humans, Cow, Oxygen, CO2 \r\n");	//Write column headers

	}//End Start()--------------------------------------------------------------------------------------------------------


	// Update is called once per frame
	void Update () {

		//EntityCounts();
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
	/// Initialize ecosystem variables to user in/put;
	/// </summary>
	private void Initialization()
	{
		//set values to user input
		EcosystemAtmosphere.Oxygen = initialOxygen;
		EcosystemAtmosphere.Co = initialCo;
		EcosystemEnvironment.Temperature = initialTemperature;
		EcosystemEnvironment.Humidity = initialHumidity;
		dir = saveLocation + "\\saveTest_" + System.DateTime.Now.ToString("HHmm_d_M_yy") + ".txt";
	}//End Initialization()--------------------------------------------------------------------------------------------------------

	// Get entity counts
	private void EntityCounts()
	{
		EcosystemEntityTree.EcoUpdate ();
		EcosystemEntityHuman.EcoUpdate ();
		EcosystemEntityCow.EcoUpdate ();

	}


	/// <summary>
	/// Ecosystems the calculations.
	/// </summary>
	void EcosystemCalculations()
	{
		EcosystemAtmosphere.Oxygen += EcosystemAtmosphere.OxygenCalc;
		EcosystemAtmosphere.Co += EcosystemAtmosphere.CoCalc;

		humanList = GameObject.FindGameObjectsWithTag ("ecosystemHuman");
		cowList = GameObject.FindGameObjectsWithTag ("ecosystemCow");

		EcosystemPostCalculations();
	}//End EcosystemCalculations()--------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Ecosystems the post calculations.
	/// </summary>
	void EcosystemPostCalculations()
	{

		EcosystemEntityTree tree = new EcosystemEntityTree();
		EcosystemEntityHuman human = new EcosystemEntityHuman();
		EcosystemEntityCow cow = new EcosystemEntityCow();
		
		//Create Tree
		if (EcosystemAtmosphere.Co > 90) {
			tree.Create();
		}

		//Create Human
		if (EcosystemAtmosphere.Oxygen > 90) {
			human.Create();
		}
		//Create Cow
		if (EcosystemAtmosphere.Oxygen > 140) {
			cow.Create();
		}

		//Destroy Tree
		if (EcosystemAtmosphere.Co < 8) {
			tree.Remove();
		}
		
		//Destroy Human
		if (EcosystemAtmosphere.Oxygen < 8) {
			human.Remove();
		}
		//Destroy Cow
		if (EcosystemAtmosphere.Oxygen < 15) {
			cow.Remove();
		}




	}// End EcosystemPostCalculations()--------------------------------------------------------------------------------------------------------


	/// <summary>
	/// Ecosystems the console log.
	/// </summary>
	void EcosystemConsoleLog()
	{

	}// End EcosystemConsoleLog()--------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Ecosystem data Log
	/// -Logs data to an xml file
	/// </summary>
	void EcosystemDataLog()
	{
		//File Write Test]
		//string dir = saveLocation + "\\saveTest.txt";
		string[] printme = {EcosystemEntityTree.Count + "", ", " + EcosystemEntityHuman.Count, ", "+ EcosystemEntityCow.Count, ", " + EcosystemAtmosphere.Oxygen, ", " + EcosystemAtmosphere.Co + "\r\n"};
		for (int i = 0; i<printme.Length; i++) 
		{
			File.AppendAllText(dir, printme[i]);
		}

	}// End EcosystemDataLog()--------------------------------------------------------------------------------------------------------
}

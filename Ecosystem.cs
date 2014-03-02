﻿/*************************************************************************
  Ecosystem Main Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Initializes Ecosystem

 ------------------------------------------------------------------------
  History:30/12/13 - Transfered to C#

	Rewriting Ecosystem

 ------------------------------------------------------------------------
 Contents
	1.	Imports
	2.	Variables
		2.1.	Adustable Variables
		2.2.	Rigidbodies
		2.3.	Settings
	3.	Standard Functions
		3.1. 	Start()
		3.2.	Update()
		3.3.	Initialization()
	4.	Unique Functions
		4.1.	EntityCounts()
		4.2.	EcosystemCalculations()
	5.	Debug functions
		5.1.	EcosystemConsoleLog()
		5.2.	EcosystemDataLog()
		
 *************************************************************************/




//1// IMPORTS
using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;




public class Ecosystem : MonoBehaviour {
//2// VARIABLES
	//2.1// Input (User)
	public int updateRate = 500;
	public int updateCount = 0;

	public double initialOxygen = 10;
	public double initialCo = 10;
	public double initialTemperature = 27;
	public double initialHumidity = 45;

	//2.2// Rigidbodys
	public Rigidbody treeModel;
	public Rigidbody humanModel;
	public Rigidbody cowModel;
	public Transform spawnPlane;

	//2.3//
	public string saveLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Ecosystem";
	string dir;
	//--------------------------------------------------------------------------------------------------------

//3// STANDARD FUNCTIONS


	//3.1// Use this for initialization
	void Start () {
		Initialization ();
		EntityCounts();

		File.WriteAllText (dir, "Trees, Humans, Cow, Oxygen, CO2 \r\n");	//Write column headers

	}//End Start()--------------------------------------------------------------------------------------------------------

	//3.2//
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

	//3.3//
	/// Initialize ecosystem variables to user in/put;
	private void Initialization()
	{
		//set values to user input
		EcosystemAtmosphere.Oxygen = initialOxygen;
		EcosystemAtmosphere.Co = initialCo;
		EcosystemEnvironment.Temperature = initialTemperature;
		EcosystemEnvironment.Humidity = initialHumidity;
		dir = saveLocation + "\\saveTest_" + System.DateTime.Now.ToString("HHmm_d_M_yy") + ".txt";
	}//End Initialization()--------------------------------------------------------------------------------------------------------

//4// UNIQUE FUNCTIONS
	//4.1//
	// Run entity Ecoupdate functions
	private void EntityCounts()
	{
		EcosystemEntityTree.EcoUpdate ();
		EcosystemEntityHuman.EcoUpdate ();
		EcosystemEntityCow.EcoUpdate ();

	}

	//4.2//
	/// Ecosystems the calculations.
	void EcosystemCalculations()
	{
		EcosystemAtmosphere.Oxygen += EcosystemAtmosphere.OxygenCalc;
		EcosystemAtmosphere.Co += EcosystemAtmosphere.CoCalc;

		//humanList = GameObject.FindGameObjectsWithTag ("ecosystemHuman");
		//cowList = GameObject.FindGameObjectsWithTag ("ecosystemCow");

		EcosystemPostCalculations();
	}

	//4.3//
	/// Ecosystems the post calculations.
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
	}

//5// DEBUG FUNCTIONS
	//5.1// console log.
	void EcosystemConsoleLog()
	{

	}

	//5.2//
	/// -Logs data to an xml file
	void EcosystemDataLog()
	{
		//File Write Test]
		//string dir = saveLocation + "\\saveTest.txt";
		string[] printme = {EcosystemEntityTree.Count + "", ", " + EcosystemEntityHuman.Count, ", "+ EcosystemEntityCow.Count, ", " + EcosystemAtmosphere.Oxygen, ", " + EcosystemAtmosphere.Co + "\r\n"};
		for (int i = 0; i<printme.Length; i++) 
		{
			File.AppendAllText(dir, printme[i]);
		}

	}
}

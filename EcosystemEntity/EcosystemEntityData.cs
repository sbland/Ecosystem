/*************************************************************************
  Ecosystem Entity Data holder
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:02/03/14
  Description: Holds information/data on number of entities and the current growth rate

 ------------------------------------------------------------------------
  History:

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

public class EcosystemEntityData : MonoBehaviour
{

	public class Data
	{
		public int count = 0;
		public float growthRate = 1;
		public float createRate = 1;
		public float removeRate = 1;

		public Data(int countIn, float growthIn, float createIn, float removeIn)
		{
			count = countIn;
			growthRate = growthIn;
			createRate = createIn;
			removeRate = removeIn;
		}

		public Data()
		{

		}


	}

	public static Data Trees = new Data();
	public static Data Humans = new Data();
	public static Data Cows = new Data();


	//public static EcosystemEntity[] entityCatalogue = new EcosystemEntity[4];
	//public static List<EcosystemEntity> entityCatalogue = new List<EcosystemEntity>();
	//public static string[] entityCatalogue= new string[10];
	public static int registeredCount = 0;


	public static Dictionary<string, Data> entityDictionary = new Dictionary<string, Data>();

		// Use this for initialization
		void Start ()
		{
			//entityCatalogue = new string[10];
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}


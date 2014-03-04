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

	}

	public static Data Trees = new Data();
	public static Data Humans = new Data();
	public static Data Cows = new Data();



		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}


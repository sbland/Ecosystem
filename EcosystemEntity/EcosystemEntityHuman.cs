/*************************************************************************
  Ecosystem Human Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:02/03/14
  Description: Child class of Ecosystem Entity

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

public class EcosystemEntityHuman : EcosystemEntity
{/*
	//properties
	private static int m_count = 0;
	public double m_coChange = 5;
	public double m_oxygenChange = -5;

	public int updateRate = 500;
	public int updateCount = 0;

	public GameObject model;
	
	static GameObject[] entityList;


	//property methods
	new public int Count {
		get{
			return m_count;
		}
		set{
			if(value>=0)
			{
				m_count = value;
			}		
		}
	}
	
	new public double CoChange {
		get{
			return m_coChange;
		}
		set{
			m_coChange = value;		
		}
	}
	
	new public double OxygenChange {
		get{
			return m_oxygenChange;
		}
		set{
			m_oxygenChange = value;		
		}
	}
	
	//3// STANDARD FUNCTIONS
	
	
	//3.1// Use this for initialization
	void Start () {
		CheckCount ();
	}//End Start()--------------------------------------------------------------------------------------------------------
	
	//3.2//
	// Update is called once per frame
	void Update () {
		
		//EntityCounts();
		if (updateCount == updateRate) 
		{
			updateCount = 0;
			if (Ecosystem.atmosphere.Oxygen > 90) {
				Create();
			}
	
			if (Ecosystem.atmosphere.Oxygen < 8) {
				Remove();
			}

		}
		updateCount++;

	}//End Update()--------------------------------------------------------------------------------------------------------




	public static void CheckCount ()
	{
		entityList = GameObject.FindGameObjectsWithTag (this.tag);
		Count = entityList.Length;
	}
	
	new public bool Create()
	{
		if (model != null) {
			Rigidbody newInstance;
			Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
			newInstance = MonoBehaviour.Instantiate (this, this.rigidbody.position + position, this.rigidbody.rotation) as Rigidbody;
			
			Ecosystem.atmosphere.OxygenCalc += this.m_oxygenChange;
			Ecosystem.atmosphere.CoCalc += this.m_coChange;
			
			this.Count++;
			return true;
		} else {
			return false;
		}
		
	}
	
	new public bool Remove()
	{

		if (entityList.Length > 0) {
			MonoBehaviour.Destroy (this);
			Count--;
			Ecosystem.atmosphere.OxygenCalc -= m_oxygenChange;
			Ecosystem.atmosphere.CoCalc -= m_coChange;
			return true;
		} else {
			return false;
		}
		
	}
	
	new public bool Remove(Collider active)
	{
		entityList = GameObject.FindGameObjectsWithTag (tagName);
		
		if (entityList.Length > 0) {
			MonoBehaviour.Destroy (active.gameObject);
			Count--;
			Ecosystem.atmosphere.OxygenCalc -= m_oxygenChange;
			Ecosystem.atmosphere.CoCalc -= m_coChange;
			return true;
		} else {
			return false;
		}
		
	}

*/
}


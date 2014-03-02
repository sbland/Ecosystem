/*************************************************************************
  Ecosystem Entity Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:02/03/14
  Description: Parent entity class

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

public class EcosystemEntity
{
	//properties
	private static int m_count = 0;
	private static double m_coChange;// = 15;
	private static double m_oxygenChange;// = -5;
	
	private static string prefabName = null;// = "CowPrefab";
	private static string tagName = null;// = "ecosystemCow";
	
	
	private GameObject model = GameObject.Find(prefabName);
	private GameObject spawnPlane = GameObject.Find("SpawnPlane");
	
	static GameObject[] entityList;
	
	//Constructor
	public EcosystemEntity()
	{
		//Count ++;
	}
	
	
	//property methods
	public static int Count {
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
	
	public static double CoChange {
		get{
			return m_coChange;
		}
		set{
			m_coChange = value;		
		}
	}
	
	public static double OxygenChange {
		get{
			return m_oxygenChange;
		}
		set{
			m_oxygenChange = value;		
		}
	}
	
	
	/*public static void EcoUpdate ()
	{
		entityList = GameObject.FindGameObjectsWithTag (tagName);
		Count = entityList.Length;
	}*/
	
	public bool Create()
	{
		if (model != null) {
			Rigidbody newInstance;
			Rigidbody spawnPlaneRigid = spawnPlane.rigidbody;
			Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
			newInstance = MonoBehaviour.Instantiate (this.model, spawnPlaneRigid.position + position, spawnPlaneRigid.rotation) as Rigidbody;
			
			Ecosystem.atmosphere.OxygenCalc += m_oxygenChange;
			Ecosystem.atmosphere.CoCalc += m_coChange;
			
			Count++;
			return true;
		} else {
			return false;
		}
		
	}
	
	public bool Remove()
	{
		entityList = GameObject.FindGameObjectsWithTag (tagName);
		
		if (entityList.Length > 0) {
			MonoBehaviour.Destroy (entityList [entityList.Length-1]);
			Count--;
			return true;
		} else {
			return false;
		}
		
	}
	
	public bool Remove(Collider active)
	{
		entityList = GameObject.FindGameObjectsWithTag (tagName);
		
		if (entityList.Length > 0) {
			MonoBehaviour.Destroy (active.gameObject);
			Count--;
			return true;
		} else {
			return false;
		}
		
	}
}

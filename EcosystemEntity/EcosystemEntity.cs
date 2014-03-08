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

public class EcosystemEntity : MonoBehaviour
{
	//properties
	public float m_coChange = 0f;
	public float m_oxygenChange = 0f;

	public float oxygenReqUpper = 0f;
	public float oxygenReqLower = 0f;
	public float coReqUpper = 0f;
	public float coReqLower = 0f;

	public float tempLimitUpper = 0f;
	public float tempLimitLower = 0f;

	public float growthAmount = 1f;

	public int updateRate = 500;
	public int updateCount = 0;

	public string entityName = null;

	public bool registered = false;

	//property methods

	public float CoChange {
		get{
			return m_coChange;
		}
		set{
			m_coChange = value;		
		}
	}
	
	public float OxygenChange {
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

		//UpdateCount ();
		gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

		//Register entity to collection
		if (!registered) {
			Register();
			EcosystemEntityData.entityDictionary [entityName].Count++;
			Ecosystem.atmosphere.OxygenCalc += this.m_oxygenChange;
			Ecosystem.atmosphere.CoCalc += this.m_coChange;
		} else {
			EcosystemEntityData.entityDictionary [entityName].Count++;
			Ecosystem.atmosphere.OxygenCalc += this.m_oxygenChange;
			Ecosystem.atmosphere.CoCalc += this.m_coChange;
		}
	}//End Start()--------------------------------------------------------------------------------------------------------
	
	//3.2//
	// Update is called once per frame
	void Update () {

	}//End Update()--------------------------------------------------------------------------------------------------------


	void FixedUpdate(){
		
		//EntityCounts();
		if (updateCount == updateRate) 
		{
			updateCount = 0;
			Debug.Log(entityName + " updating");
			EcoCalculations ();	
		}
		updateCount++;

		
	}

	//4.1//
	public void EcoCalculations()
	{

		int seed = Random.Range (0, 10);
		if (chanceConvert (EcosystemEntityData.entityDictionary [entityName].m_createRate, seed)) {
			if (chanceConvert (EcosystemEntityData.entityDictionary [entityName].m_createRate, seed)) {
				Debug.Log ("Create " + entityName);
				Create ();
			}else{
				Debug.Log ("Grow " + entityName);
				Growth();
			}
		
		} else if (chanceConvert (EcosystemEntityData.entityDictionary [entityName].m_removeRate, seed)) {
				Debug.Log ("Remove " + entityName);
				Remove ();
		}

	}

	// weighted true or false check
	public static bool chanceConvert(float inputChance, int seed)
	{
		inputChance = inputChance * 10;
		
		
		
		if (seed > inputChance) {
			return false;
		}else{
			return true;
		}
	}

		
	//4.2//
	public void Register()
	{
		EcosystemEntityData.Data newData = new EcosystemEntityData.Data (updateRate,
		                                                                 growthAmount,
		                                                                 m_coChange,
		                                                                 m_oxygenChange,
		                                                                 oxygenReqUpper,
		                                                                 coReqUpper,
		                                                                  tempLimitUpper
		                                                                 );
		EcosystemEntityData.entityDictionary.Add (entityName, newData);
		EcosystemEntityData.registeredCount++;
		
		registered = true;
	}
	
	//4.3//
	public bool Create()
	{

		Rigidbody newInstance;
		Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
		newInstance = MonoBehaviour.Instantiate (gameObject, gameObject.rigidbody.position + position, gameObject.rigidbody.rotation) as Rigidbody;
		return true;

	}

	//4.4//
	public bool Remove()
	{
		EcosystemEntityData.entityDictionary [entityName].Count--;
		Ecosystem.atmosphere.OxygenCalc -= m_oxygenChange;
		Ecosystem.atmosphere.CoCalc -= m_coChange;

		MonoBehaviour.Destroy (gameObject);
		return true;
	}


	//4.5//
	public void Growth()
	{
		gameObject.rigidbody.transform.localScale = new Vector3(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f);
	}

}


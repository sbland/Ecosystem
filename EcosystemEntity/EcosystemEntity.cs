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
	public double m_coChange = 0;
	public double m_oxygenChange = 0;

	public double oxygenReqUpper = 0;
	public double oxygenReqLower = 0;
	public double coReqUpper = 0;
	public double coReqLower = 0;

	public double tempLimitUpper = 0;
	public double tempLimitLower = 0;

	public float growthAmount = 1;

	public int updateRate = 500;
	public int updateCount = 0;

	public string entityName = null;

	public bool registered = false;

	//property methods

	public double CoChange {
		get{
			return m_coChange;
		}
		set{
			m_coChange = value;		
		}
	}
	
	public double OxygenChange {
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
						//EcosystemEntityData.entityCatalogue [EcosystemEntityData.registeredCount] = entityName;
						EcosystemEntityData.Data newData = new EcosystemEntityData.Data (0, 1f, 1f, 1f);
						EcosystemEntityData.entityDictionary.Add (entityName, newData);
						EcosystemEntityData.registeredCount++;

						EcosystemEntityData.entityDictionary [entityName].count++;
						registered = true;
				} else {
						EcosystemEntityData.entityDictionary [entityName].count++;
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
			EcoCalculations ();
			updateCount = 0;		
		}
		updateCount++;

		
	}

	//4.1//
	public void EcoCalculations()
	{
		updateCount = 0;
		if (Ecosystem.atmosphere.Oxygen >= oxygenReqUpper 
		    && Ecosystem.atmosphere.Co >= coReqUpper
		    && Ecosystem.environment.Temperature >= tempLimitLower
		    && Ecosystem.environment.Temperature <= tempLimitUpper
		    )
		{
			Create();
		}
		
		if (Ecosystem.atmosphere.Oxygen <= oxygenReqLower 
		    || Ecosystem.atmosphere.Co <= coReqLower
		    || Ecosystem.environment.Temperature <= tempLimitLower
		    || Ecosystem.environment.Temperature >= tempLimitUpper
		    )
		{
			Remove();
		}
		
		Growth();
	}
	
	//4.2//
	public void UpdateCount ()
	{
		EcosystemEntityData.entityDictionary [entityName].count++;

		/*switch (this.entityName) {
			case "Human":
			{
				EcosystemEntityData.Humans.count++;
				break;
			}
			case "Cow":
			{
				EcosystemEntityData.Cows.count++;
				break;
			}
			case "Tree":
			{
				EcosystemEntityData.Trees.count++;
				break;
			}
			default:
			{
				break;
			}
		}*/
	}

	//4.3//
	public bool Create()
	{

		Rigidbody newInstance;
		Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
		newInstance = MonoBehaviour.Instantiate (gameObject, gameObject.rigidbody.position + position, gameObject.rigidbody.rotation) as Rigidbody;
		
		Ecosystem.atmosphere.OxygenCalc += this.m_oxygenChange;
		Ecosystem.atmosphere.CoCalc += this.m_coChange;


		return true;



				
	}

	//4.4//
	public bool Remove()
	{
		EcosystemEntityData.entityDictionary [entityName].count--;
		/*switch (this.entityName) {
		case "Human":
		{
			EcosystemEntityData.Humans.count--;
			break;
		}
		case "Cow":
		{
			EcosystemEntityData.Cows.count--;
			break;
		}
		case "Tree":
		{
			EcosystemEntityData.Trees.count--;
			break;
		}
		default:
		{
			break;
		}
		}*/
			
			
			//Count--;
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


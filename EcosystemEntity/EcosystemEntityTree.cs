using UnityEngine;
using System.Collections;

public class EcosystemEntityTree : EcosystemEntity
{
	//properties
	private static int m_count = 0;
	private static double m_coChange = -20;
	private static double m_oxygenChange = 20;

	
	private GameObject TreeModel = GameObject.Find("TreePrefab");
	private GameObject spawnPlane = GameObject.Find("SpawnPlane");


	//Constructor
	public EcosystemEntityTree()
	{
		Count ++;
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


	public static double[] EcoUpdate ()
	{
		double[] result = new double[2];
		
		result[0] = m_oxygenChange * m_count;
		result[1] = m_coChange * m_count;
		
		return result;
	}

	public bool Create()
	{
		Rigidbody humanInstance;
		Rigidbody spawnPlaneRigid = spawnPlane.rigidbody;
		Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
		humanInstance = MonoBehaviour.Instantiate (TreeModel, spawnPlaneRigid.position + position, spawnPlaneRigid.rotation) as Rigidbody;

		EcosystemAtmosphere.OxygenCalc += m_oxygenChange;
		EcosystemAtmosphere.CoCalc += m_coChange;

		Count++;
		return true;
	}
}


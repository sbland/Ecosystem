using UnityEngine;
using System.Collections;

public class EcosystemEntityCow
{
	//properties
	private static int m_count = 0;
	private static double m_coChange = -200;
	private static double m_oxygenChange = 20;

	private GameObject CowModel = GameObject.Find("CowPrefab");
	private GameObject spawnPlane = GameObject.Find("SpawnPlane");

		
	//Constructor
	public EcosystemEntityCow()
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
		humanInstance = MonoBehaviour.Instantiate (CowModel, spawnPlaneRigid.position + position, spawnPlaneRigid.rotation) as Rigidbody;
		
		Count++;
		return true;
	}
}


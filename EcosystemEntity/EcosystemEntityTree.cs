using UnityEngine;
using System.Collections;

public class EcosystemEntityTree : EcosystemEntity
{
	//properties
	private static int m_count = 0;
	private static double m_coChange = -20;
	private static double m_oxygenChange = 20;
	
	private static string prefabName = "TreePrefab";
	private static string tagName = "ecosystemTrees";
	
	
	private GameObject model = GameObject.Find(prefabName);
	private GameObject spawnPlane = GameObject.Find("SpawnPlane");
	
	static GameObject[] entityList;
	
	//Constructor
	public EcosystemEntityTree()
	{
		//Count ++;
	}
	
	
	
	//property methods
	new public static int Count {
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
	
	new public static double CoChange {
		get{
			return m_coChange;
		}
		set{
			m_coChange = value;		
		}
	}
	
	new public static double OxygenChange {
		get{
			return m_oxygenChange;
		}
		set{
			m_oxygenChange = value;		
		}
	}
	
	
	public static void EcoUpdate ()
	{
		entityList = GameObject.FindGameObjectsWithTag (tagName);
		Count = entityList.Length;
	}
	
	new public bool Create()
	{
		if (model != null) {
			Rigidbody newInstance;
			Rigidbody spawnPlaneRigid = spawnPlane.rigidbody;
			Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
			newInstance = MonoBehaviour.Instantiate (model, spawnPlaneRigid.position + position, spawnPlaneRigid.rotation) as Rigidbody;
			
			EcosystemAtmosphere.OxygenCalc += m_oxygenChange;
			EcosystemAtmosphere.CoCalc += m_coChange;
			
			Count++;
			return true;
		} else {
			return false;
		}
		
	}
	
	new public bool Remove()
	{
		entityList = GameObject.FindGameObjectsWithTag (tagName);
		
		if (entityList.Length > 0) {
			MonoBehaviour.Destroy (entityList [entityList.Length-1]);
			Count--;
			EcosystemAtmosphere.OxygenCalc -= m_oxygenChange;
			EcosystemAtmosphere.CoCalc -= m_coChange;
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
			EcosystemAtmosphere.OxygenCalc -= m_oxygenChange;
			EcosystemAtmosphere.CoCalc -= m_coChange;
			return true;
		} else {
			return false;
		}
		
	}
}


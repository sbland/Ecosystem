using UnityEngine;
using System.Collections;

public class EcosystemEntityHuman// : ScriptableObject// : EcosystemEntity
{
	//properties
	private static int m_count = 0;
	private static double m_coChange = -200;
	private static double m_oxygenChange = 20;

	//private EcosystemEntityHuman self = new EcosystemEntityHuman();
	//public Rigidbody HumanModel;
	public GameObject humanModel = GameObject.Find("HumanPrefab");



	//Constructor
	public EcosystemEntityHuman()
	{
		Count ++;
		//humanModel = HumanModel;
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

	//public Rigidbody treePrefab;
	// Use this for initialization
	void Start ()
	{
		//Instantiate (treePrefab);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
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
	

	new public static double[] EcoUpdate ()
	{
		double[] result = new double[2];

		result[0] = m_oxygenChange * m_count;
		result[1] = m_coChange * m_count;

		return result;
	}

	public bool Create()
	{
		Rigidbody humanInstance;
		Vector3 position = new Vector3 (Random.Range (-10.0F, 10.0F), 0, Random.Range (-10.0F, 10.0F));	
		humanInstance = MonoBehaviour.Instantiate (humanModel, Ecosystem.spawnPlane.position + position, Ecosystem.spawnPlane.rotation) as Rigidbody;
		EcosystemEntityHuman.Count++;
		return true;
	}
}


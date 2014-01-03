using UnityEngine;
using System.Collections;

public class EcosystemEntityTree
{
	//properties
	private static int m_count = 0;
	private static double m_coConsumption = 2;
	private static double m_oxygenRelease = 20;

	public class TreeModel : MonoBehaviour
	{
		public Rigidbody treePrefab;
		// Use this for initialization
		void Start ()
		{
			Instantiate (treePrefab);
		}
		
		// Update is called once per frame
		void Update ()
		{
			
		}
	}


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
			m_count = value;		
		}
	}

	public static double CoConsumption {
		get{
			return m_coConsumption;
		}
		set{
			m_coConsumption = value;		
		}
	}
	
	public static double OxygenRelease {
		get{
			return m_oxygenRelease;
		}
		set{
			m_oxygenRelease = value;		
		}
	}

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{

	}
}


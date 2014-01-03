using UnityEngine;
using System.Collections;

public class EcosystemEntityHuman
{
	//properties
	private static int m_count = 0;
	private static double m_oxygenConsumption = 2;
	private static double m_coRelease = 20;

	public Rigidbody humanPrefab;
	

	//methods
	public static int Count {
		get{
			return m_count;
		}
		set{
			m_count = value;		
		}
	}

	public static double OxygenConsumption {
		get{
			return m_oxygenConsumption;
		}
		set{
			m_oxygenConsumption = value;		
		}
	}

	public static double coRelease {
		get{
			return m_coRelease;
		}
		set{
			m_coRelease = value;		
		}
	}


	//Constructor
	public EcosystemEntityHuman()
	{
		Count++;
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


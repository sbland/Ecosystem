using UnityEngine;
using System.Collections;

public class EcosystemEntityCow : EcosystemEntity
{

	//properties
	private static int m_count = 0;
	private static double m_oxygenConsumption = 14;
	private static double m_coRelease = 15;
	
	public Rigidbody cowPrefab;
	
	
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
	public EcosystemEntityCow()
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


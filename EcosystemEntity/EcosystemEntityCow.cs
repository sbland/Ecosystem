using UnityEngine;
using System.Collections;

public class EcosystemEntityCow : EcosystemEntity
{

	//properties
	private static int m_count = 0;
	private static double m_oxygenChange = 0;
	private static double m_coChange = 0;
	
	public Rigidbody cowPrefab;
	
	
	//methods
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
	
	public static double OxygenConsumption {
		get{
			return m_oxygenChange;
		}
		set{
			m_oxygenChange = value;		
		}
	}
	
	public static double coRelease {
		get{
			return m_coChange;
		}
		set{
			m_coChange = value;		
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

	public static void EcoUpdate ()
	{
		//EcosystemAtmosphere.Oxygen += m_oxygenChange * m_count;
		//EcosystemAtmosphere.Co += m_coChange * m_count;
	}
}


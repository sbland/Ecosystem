using UnityEngine;
using System.Collections;

public class EcosystemEntityHuman
{
	//properties
	private static int m_count = 0;
	private static double m_coChange = -200;
	private static double m_oxygenChange = 20;
	
	public class HumanModel : MonoBehaviour
	{
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
	}
	
	
	//Constructor
	public EcosystemEntityHuman()
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
}


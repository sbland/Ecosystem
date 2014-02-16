using UnityEngine;
using System.Collections;

public class EcosystemEntity// : MonoBehaviour
{
	private int m_count = 0;

	public int Count {
		get{
			return m_count;
		}
		set{
			m_count = value;		
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


	public static void EcoUpdate ()
	{
		//EcosystemAtmosphere.Oxygen -= m_oxygenConsumption * m_count;
		//EcosystemAtmosphere.Co += m_coRelease * m_count;
	}
}


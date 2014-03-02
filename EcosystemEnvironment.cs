using UnityEngine;
using System.Collections;

public class EcosystemEnvironment : MonoBehaviour
{
		public double m_temperature;
		public double m_humidity;

		public double Temperature
		{
			get
			{
				return m_temperature;
			}
			set
			{
				m_temperature = value;
			}
		}
		public double Humidity
		{
			get
			{
				return m_humidity;
			}
			
			set
			{
				m_humidity = value;
			}
		}
	                    
	public sealed class Units
	{
		public static readonly string Temperature = "°C Temperature";
		public static readonly string Humidity = "% Humidity";
	}
}




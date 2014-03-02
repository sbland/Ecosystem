using UnityEngine;
using System.Collections;

public static class EcosystemEnvironment
{
		private static double m_temperature;
		private static double m_humidity;

		public static double Temperature
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
		public static double Humidity
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




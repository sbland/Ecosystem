/*************************************************************************
  Ecosystem Atmosphere
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Initializes Ecosystem

 ------------------------------------------------------------------------
  History:30/12/13 - Transfered to C#


*************************************************************************/

using UnityEngine;
using System.Collections;

public static class EcosystemAtmosphere
{
	private static double m_oxygen; 	//O2
	private static double m_co;			//CO2
	private static double m_nitrogen;	//N2
	private static double m_argon;		//Ar
	private static double m_neon;		//Ne
	private static double m_helium;		//He
	private static double m_methane;	//CH4
	private static double m_hydrogen;	//Ar
	private static double m_krypton;	//Ar

	private static double m_oxygenCalc = 0;
	private static double m_coCalc = 0;


	public	static double OxygenCalc
	{
		get
		{
			return m_oxygenCalc;
		}
		set
		{
			m_oxygenCalc = value;
			
		}
	}public	static double CoCalc
	{
		get
		{
			return m_coCalc;
		}
		set
		{
			m_coCalc = value;
			Debug.Log(value);	
		}
	}


	public	static double Co
	{
		get
		{
			return m_co;
		}
		set
		{
			if(value>=0){
				m_co = value;
			}else{
				m_co = 0;
			}

		}
	}

	public	static double Oxygen
	{
		get
		{
			return m_oxygen;
		}
		set
		{
			if(value>=0){
				m_oxygen = value;
			}else{
				m_oxygen = 0;
			}
		}
	}

	public	static double Nitrogen
	{
		get
		{
			return m_nitrogen;
		}
		set
		{
			if(value>=0)
			{
			m_nitrogen = value;
			}
		}
	}
	
	public	static double Argon
	{
		get
		{
			return m_argon;
		}
		set
		{
			if(value>=0)
			{
			m_argon = value;
			}
		}
	}

	public	static double Neon
	{
		get
		{
			return m_neon;
		}
		set
		{
			m_neon = value;
		}
	}

	public	static double Helium
	{
		get
		{
			return m_helium;
		}
		set
		{
			m_helium = value;
		}
	}

	public	static double Methane
	{
		get
		{
			return m_methane;
		}
		set
		{
			m_methane = value;
		}
	}

	public	static double Hydrogen
	{
		get
		{
			return m_hydrogen;
		}
		set
		{
			m_hydrogen = value;
		}
	}

	public	static double Krypton
	{
		get
		{
			return m_krypton;
		}
		set
		{
			m_krypton = value;
		}
	}

	
	public sealed class Units
	{
		public static readonly string Oxygen = "% Oxygen";
		public static readonly string Co = "% Co2";
		public static readonly string Nitrogen = "% Nitrogen";
		public static readonly string Argon = "% Argon";
		public static readonly string Neon = "% Neon";
		public static readonly string Helium = "% Helium";
		public static readonly string Methane = "% Methane";
		public static readonly string Hydrogen = "% Hydrogen";
		public static readonly string Krypton = "% Krypton";
		
	}
}


	

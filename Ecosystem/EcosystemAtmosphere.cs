/*************************************************************************
  Ecosystem Atmosphere Class
  Copyright (C), SBland.co.uk
 -------------------------------------------------------------------------

  Date:09/11/13
  Description: Controls atmosphere systems

 ------------------------------------------------------------------------
  History:30/12/13 - Transfered to C#

 ------------------------------------------------------------------------
 Contents
	1.	Imports
	2.	Variables
		2.1.
	3.	Standard Functions
		3.1. 	
	4.	Unique Functions
		4.1.	
	5.	Debug functions
		5.1.	


*************************************************************************/

using UnityEngine;
using System.Collections;

public class EcosystemAtmosphere  : MonoBehaviour
{
	public double m_oxygen; 	//O2
	private double m_co;			//CO2
	private static double m_nitrogen;	//N2
	private static double m_argon;		//Ar
	private static double m_neon;		//Ne
	private static double m_helium;		//He
	private static double m_methane;	//CH4
	private static double m_hydrogen;	//Ar
	private static double m_krypton;	//Ar

	private double m_oxygenCalc = 0;
	private double m_coCalc = 0;


	public	double OxygenCalc
	{
		get
		{
			return m_oxygenCalc;
		}
		set
		{
			m_oxygenCalc = value;
			
		}
	}public	double CoCalc
	{
		get
		{
			return m_coCalc;
		}
		set
		{
			m_coCalc = value;
		}
	}


	public	double Co
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

	public	double Oxygen
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


	

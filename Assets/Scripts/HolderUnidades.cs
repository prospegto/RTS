using UnityEngine;
using System.Collections.Generic;

public class HolderUnidades : MonoBehaviour 
{
	private static PropUnidadesMoviles[] propMov;
	private static PropUnidadesEstaticas[] propEstatic;
	private const string xmlMovil = "XML/InfoUnidades";
	private const string xmlEstatic = "XMl/InfoEdificios";

	void Start ()
	{
		TextAsset charactersInfo = Resources.Load<TextAsset> (xmlMovil);
		propMov = XMLParser.ParseUnidades (charactersInfo.text);
		TextAsset buildingsInfo = Resources.Load<TextAsset> (xmlEstatic);
		propEstatic = XMLParser.ParseEdificios (buildingsInfo.text);
	}

	public static PropUnidades CargarUnidadPorID (int id)
	{
		foreach (PropUnidadesMoviles m in propMov) 
		{
			if(m.Id == id)
			{
				return m;
			}
		}

		foreach (PropUnidadesEstaticas s in propEstatic) 
		{
			if(s.Id == id)
			{
				return s;
			}
		}

		return null;
	}

	public static PropUnidades[] CargarUnidadDisponibleEn (int id)
	{
		List<PropUnidades> returnList = new List<PropUnidades> ();

		foreach (PropUnidadesMoviles m in propMov)
		{
			if(m.DisponibleEn == id)
			{
				returnList.Add(m);
			}
		}

		foreach (PropUnidadesEstaticas s in propEstatic)
		{
			if(s.DisponibleEn == id)
			{
				returnList.Add(s);
			}
		}

		return returnList.ToArray ();
	}
}

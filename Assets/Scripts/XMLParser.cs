using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class XMLParser {


	public static PropUnidadesEstaticas[] ParseEdificios (string content){
		XmlReader reader = XmlReader.Create (new StringReader (content));
		List<PropUnidadesEstaticas> entities = new List<PropUnidadesEstaticas> ();
		PropUnidadesEstaticas current = null;
		while (reader.Read()) 
		{
			if(reader.IsStartElement("edificio"))
			{
				if(current != null)
				{
					entities.Add(current);
				}
				current = new PropUnidadesEstaticas();
			}
			if(current != null)
			{
				if(reader.IsStartElement("id"))
				{
					current.Id = reader.ReadElementContentAsInt();
				}
				if(reader.IsStartElement("nombre"))
				{
					current.Nombre = reader.ReadElementContentAsString();
				}
				if(reader.IsStartElement("recursos"))
				{
					int comida, madera, oro = 0;
					comida = int.Parse(reader.GetAttribute("comida"));
					oro = int.Parse(reader.GetAttribute("oro"));
					madera = int.Parse(reader.GetAttribute("madera"));
					current.RecursosNecesarios = new SetRecursos(madera, comida, oro);
				}
				if(reader.IsStartElement("descripcion"))
				{
					current.Descricion = reader.ReadElementContentAsString();
				}
				if(reader.IsStartElement("disponibleEn"))
				{
					current.DisponibleEn = reader.ReadElementContentAsInt();
				}
				if(reader.IsStartElement("level"))
				{
					current.Level = reader.ReadElementContentAsInt();
				}
				if(reader.IsStartElement("script"))
				{

				}
			}
		}

		if (current != null)
		{
			entities.Add(current);
		}

		return entities.ToArray();
	}

	public static PropUnidadesMoviles[] ParseUnidades (string content)
	{
		XmlReader reader = XmlReader.Create (new StringReader (content));
		List<PropUnidadesMoviles> entities = new List<PropUnidadesMoviles> ();
		PropUnidadesMoviles current = null;
		while (reader.Read()) 
		{
			if(reader.IsStartElement("unidad"))
			{
				if(current != null)
				{
					entities.Add(current);
				}
				current = new PropUnidadesMoviles();
			}
			if(current != null)
			{
				if(reader.IsStartElement("id"))
				{
					current.Id = reader.ReadElementContentAsInt();
				}
				if(reader.IsStartElement("nombre"))
				{
					current.Nombre = reader.ReadElementContentAsString();
				}
				if(reader.IsStartElement("recursos"))
				{
					int comida, madera, oro = 0;
					comida = int.Parse(reader.GetAttribute("comida"));
					oro = int.Parse(reader.GetAttribute("oro"));
					madera = int.Parse(reader.GetAttribute("madera"));
					current.RecursosNecesarios = new SetRecursos(madera, comida, oro);
				}
				if(reader.IsStartElement("description"))
				{
					current.Descricion = reader.ReadElementContentAsString();
				}
				if(reader.IsStartElement("disponibleEn"))
				{
					current.DisponibleEn = reader.ReadElementContentAsInt();
				}
				if(reader.IsStartElement("level"))
				{
					current.Level = reader.ReadElementContentAsInt();
				}
			}
		}
		
		if (current != null)
		{
			entities.Add(current);
		}
		
		return entities.ToArray();
	}
}
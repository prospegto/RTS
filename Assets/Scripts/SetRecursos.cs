using UnityEngine;
using System.Collections;

[System.Serializable]
public class SetRecursos{
	public int madera, comida, oro;
	
	public SetRecursos (int madera, int comida, int oro)
	{
		this.madera = madera;
		this.comida = comida;
		this.oro = oro;	
	}
}
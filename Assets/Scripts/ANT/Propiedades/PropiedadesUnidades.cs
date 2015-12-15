using UnityEngine;
using System.Collections;

[System.Serializable]
public class PropiedadesUnidades{

	public float vidaMaxima;
	private float vidaActual;


	public float GasolinaActual{
		get{
			return vidaActual;
		}
	}

	public void Inicializar(){
		vidaActual = vidaMaxima;
	}
}

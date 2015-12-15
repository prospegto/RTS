using UnityEngine;
using System.Collections;

public class PropiedadesCamion : PropiedadesUnidadesMoviles {

	public TipoRecursos recursoActual;
	public int cantidadActualRecurso;
	public int capacidadRecurso;
	public int cantidadPorSegundo;

	public bool EstaLleno{
		get{
			return cantidadActualRecurso >= capacidadRecurso;
		}
	}

	public void DarRecursos(IAlmacenRecursos recibir){
		recibir.RecibirRecurso(cantidadActualRecurso, recursoActual);
		cantidadActualRecurso = 0;
	}
}

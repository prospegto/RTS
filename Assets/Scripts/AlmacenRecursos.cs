using UnityEngine;
using System.Collections;

public class AlmacenRecursos : UnidadEstatica, IAlmacenRecursos {

	[SerializeField]
	private TipoRecursos[] recursosAceptados;

	public TipoRecursos[] RecursosAceptados{
		get{
			return recursosAceptados;
		}
	}

	public void RecibirRecurso(int cantidad, TipoRecursos recurso){

	}

	public bool RecursoValido(TipoRecursos recurso){

		foreach(TipoRecursos mRecurso in recursosAceptados){
			if(recurso == mRecurso){
				return true;
			}
		}

		return false;
	}
}

using UnityEngine;
using System.Collections;

public class UnidadBase : MonoBehaviour {

	public Projector projectorSeleccion;
	private bool estaSeleccionada;
	//public PropiedadesUnidades propiedades;
	public int id;

	internal virtual void Start(){
		//propiedades.Inicializar();
		ControladorUnidades.AnadirUnidadesSeleccion(this);
	}

	public bool EstaSeleccionada{
		get{
			return estaSeleccionada;
		}
		set{
			estaSeleccionada = value;
			projectorSeleccion.enabled = estaSeleccionada;
		}
	}

	public virtual void AccionCallback (Vector3 objetivo){

	}

	public virtual void AccionCallback (ControladorRecursos objetivo){
		
	}
}

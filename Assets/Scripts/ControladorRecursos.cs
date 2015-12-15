using UnityEngine;

public enum TipoRecursos{
	Madera,
	Hierro,
	Comida,
	Bebida
}


public class ControladorRecursos : MonoBehaviour {

	public TipoRecursos recurso;
	[SerializeField]
	private int cantidadRecurso;
	public delegate void EventoNoRecursos();
	public event EventoNoRecursos RecursoVacio;

	public int RecogerRecurso(int cantidadExtraida){
		if(cantidadExtraida <= cantidadRecurso){
			cantidadRecurso -= cantidadExtraida;
			return cantidadExtraida;
		}else{
			cantidadRecurso = 0;
			if(RecursoVacio != null)
				RecursoVacio();
			
			return cantidadRecurso;
		}
	}


	public bool EstaVacio{
		get{
			return cantidadRecurso <=0;
		}
	}

}

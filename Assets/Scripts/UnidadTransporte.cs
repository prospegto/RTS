using UnityEngine;
using System.Collections;

public class UnidadTransporte : UnidadBase {

	//public new PropiedadesUnidadesMoviles propiedades;

	internal override void Start ()
	{
		base.Start ();
		//propiedades = new PropiedadesUnidadesMoviles();
		//propiedades.velocidadMovimiento = 2;
	}

	void OnGUI(){
		if(EstaSeleccionada){
			PropUnidades[] unidadesDisponibles = HolderUnidades.CargarUnidadDisponibleEn(base.id);
			for(int i = 0; i < unidadesDisponibles.Length; i++){
				PropUnidades actual = unidadesDisponibles[i];
				GUI.Box(new Rect(0, 40 * i, 100, 40), actual.Nombre);
			}
		}
	}

	internal IEnumerator Mover(Vector3[] path){

		for(int i = 0; i < path.Length; i++){
			Vector3 direccion = Vector3.zero;
			do{
				direccion = (path[i] - transform.position);
				MovimientoCallback(direccion.normalized);
				yield return null;
			}while(direccion.sqrMagnitude > 0.1f);
		}
	}

	public void MovimientoCallback (Vector3 direccion){
		transform.position += direccion * Time.deltaTime;
	}

	public override void AccionCallback (Vector3 objetivo)
	{
		StartCoroutine(Mover(new Vector3[1]{
			objetivo
		}));
	}

}

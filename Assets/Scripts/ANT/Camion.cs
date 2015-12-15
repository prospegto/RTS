using UnityEngine;
using System.Collections;

public class Camion : UnidadTransporte {

	public new PropiedadesCamion propiedades;

	internal override void Start(){
		base.Start();
		propiedades = new PropiedadesCamion();
		propiedades.capacidadRecurso = 10;
		propiedades.cantidadPorSegundo = 2;
		propiedades.velocidadMovimiento = 2;

	}



	private IEnumerator RecogerDeAlmacen(ControladorRecursos almacen){

		propiedades.recursoActual = almacen.recurso;

		while(!almacen.EstaVacio){
			yield return StartCoroutine(Mover(new Vector3[1]{
				almacen.transform.position
			}));
			while(!propiedades.EstaLleno){
				int unidadesQueSalen = Mathf.Min(propiedades.cantidadPorSegundo, (propiedades.capacidadRecurso - propiedades.cantidadActualRecurso));
				propiedades.cantidadActualRecurso += almacen.RecogerRecurso(unidadesQueSalen);
				yield return new WaitForSeconds(1);
			}

			IAlmacenRecursos almacenRecursos = ControladorUnidades.ObtenerRecursos(almacen.recurso, transform.position);
			yield return StartCoroutine(Mover(new Vector3[1]{
				(almacenRecursos as AlmacenRecursos).transform.position
			}));
			almacenRecursos.RecibirRecurso(propiedades.cantidadActualRecurso, propiedades.recursoActual);
			propiedades.DarRecursos(almacenRecursos);
		}
	}

	public override void AccionCallback (ControladorRecursos objetivo)
	{
		StopAllCoroutines();
		StartCoroutine(RecogerDeAlmacen(objetivo));
	}

}

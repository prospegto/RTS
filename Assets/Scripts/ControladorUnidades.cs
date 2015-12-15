using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorUnidades : MonoBehaviour {


	private Vector2 posicionInicial;
	private Vector2 posicionFinal;
	private static List<UnidadBase> listaUnidadesTrans;
	public Camera mainCamera;
	private UnidadBase[] unidadesSeleccionadas;

	void Awake(){
		listaUnidadesTrans = new List<UnidadBase>();
		unidadesSeleccionadas = new UnidadBase[0];
	}


	void Update(){

		if(Input.GetButtonDown("Fire2")){
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray.origin, ray.direction, out hit)){

				ControladorRecursos cRecursos = hit.transform.GetComponent<ControladorRecursos>();

				if(cRecursos != null){
					foreach(UnidadBase mUnidad in unidadesSeleccionadas){
						mUnidad.AccionCallback(cRecursos);
					}

					return;
				}



				foreach(UnidadBase mUnidad in unidadesSeleccionadas){
					mUnidad.AccionCallback(hit.point);
				}

			}
		}

	}

	public static void AnadirUnidadesSeleccion(UnidadBase unidad){
		listaUnidadesTrans.Add(unidad);
	}

	private UnidadBase[] SeleccionarUnidadesRaton(Rect rectanguloSeleccion){

		List<UnidadBase> unidadesSeleccionadas = new List<UnidadBase>();

		foreach(UnidadBase mUnidad in listaUnidadesTrans){
			Vector3 posicionUnidad = mainCamera.WorldToScreenPoint(mUnidad.transform.position);
			Vector2 posicionUnidad2D = new Vector2(posicionUnidad.x, Screen.height - posicionUnidad.y);
			if(rectanguloSeleccion.Contains(posicionUnidad2D)){
				// Añadimos la unidad a la selección
				unidadesSeleccionadas.Add(mUnidad);
			}
		}

		return unidadesSeleccionadas.ToArray();
	}

	public static IAlmacenRecursos ObtenerRecursos(TipoRecursos recurso, Vector3 objetivo){
		float distanciaMin = Mathf.Infinity;
		AlmacenRecursos almacen = null;

		foreach(UnidadBase mUnidad in listaUnidadesTrans){
			if(mUnidad is IAlmacenRecursos){
				float distanciaActual = Vector3.Distance(mUnidad.transform.position, objetivo);

				if(distanciaActual < distanciaMin && (mUnidad as IAlmacenRecursos).RecursoValido(recurso)){
					almacen = mUnidad as AlmacenRecursos;
					distanciaMin = distanciaActual;
				}
			}
		}

		return almacen as IAlmacenRecursos;

	}

	void OnGUI(){

		if(Input.GetButtonDown("Fire1")){
			posicionInicial = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		}

		if(Input.GetButton("Fire1")){
			posicionFinal = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
			GUI.Box(new Rect(posicionInicial.x, posicionInicial.y, posicionFinal.x - posicionInicial.x, posicionFinal.y - posicionInicial.y), "");
		}

		if(Input.GetButtonUp("Fire1")){
			// Deseleccionar
			foreach(UnidadBase mUnidad in unidadesSeleccionadas){
				mUnidad.EstaSeleccionada = false;
			}
			// Selección de unidades
			float xMin = Mathf.Min(posicionInicial.x, posicionFinal.x);
			float yMin = Mathf.Min(posicionInicial.y, posicionFinal.y);
			float width = Mathf.Abs(posicionInicial.x - posicionFinal.x);
			float height = Mathf.Abs(posicionInicial.y - posicionFinal.y);

			unidadesSeleccionadas = SeleccionarUnidadesRaton(new Rect(xMin, yMin, width, height));

			foreach(UnidadBase mUnidad in unidadesSeleccionadas){
				mUnidad.EstaSeleccionada = true;
			}
		}
	}
}

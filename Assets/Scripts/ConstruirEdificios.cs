using UnityEngine;
using System.Collections;

public class ConstruirEdificios : MonoBehaviour {

	private static GameObject edificio = null;
	private static int edificioId;
	
	public static bool TieneRecursos 
	{
		get { return edificio != null; }
	}
	
	public static void Create (int id)
	{
		edificioId = id;
		Destruir ();
		InstanciarNuevoEdificio (string.Empty);
	}
	
	public static void Destruir ()
	{
		if (edificio != null) 
		{
			Destroy(edificio);
			edificio = null;
		}
	}
	
	private static void InstanciarNuevoEdificio (string path)
	{
		edificio = GameObject.CreatePrimitive (PrimitiveType.Cube);
		edificio.GetComponent<BoxCollider> ().enabled = false;
	}
	
	private static void ConstruirEdificio ()
	{
		GameObject newBuilding = GameObject.CreatePrimitive (PrimitiveType.Cube);
		newBuilding.transform.position = edificio.transform.position;
		PropUnidadesEstaticas properties = HolderUnidades.CargarUnidadPorID (edificioId) as PropUnidadesEstaticas;
		print (newBuilding);

		Destruir ();
	}
	
	void Update () 
	{
		if (TieneRecursos) 
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(r.origin, r.direction, out hit))
			{
				edificio.transform.position = hit.point;
			}
			
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				Destruir();
			}
			
			if(Input.GetButtonDown("Fire1"))
			{
				ConstruirEdificio();
			}
		}
	}
}

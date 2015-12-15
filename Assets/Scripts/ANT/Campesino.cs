using UnityEngine;
using System.Collections;

public class Campesino : MonoBehaviour {

	public string nombre;
	public bool recibeOrden;

	void Start(){
		if(recibeOrden)
		Delegar.eventoMenuDelegado += eventoMenuDelegado;
	}

	void OnDisable(){
		Delegar.eventoMenuDelegado -= eventoMenuDelegado;
	}

	void eventoMenuDelegado(string orden){
		print("Nombre: "+nombre+ " y me mandan: "+orden);
	}
}

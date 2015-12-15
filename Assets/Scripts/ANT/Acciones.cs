using UnityEngine;
using System.Collections;
using System;

public class Acciones : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(CuentaAtras(5, () => {
			print ("Contado hasta 5");
		}));
	}


	IEnumerator CuentaAtras(int cuenta, Action accion){
		yield return new WaitForSeconds(cuenta);
		if(accion != null)
		accion();
	}
}

using UnityEngine;
using System.Collections;

public class Delegar : MonoBehaviour {

	public delegate void MenuDelegado(string orden);
	public static event MenuDelegado eventoMenuDelegado;


	void Update(){
		if(Input.GetKeyUp(KeyCode.Return)){
			if(eventoMenuDelegado != null){
				eventoMenuDelegado("1");
			}
		}
	}

}

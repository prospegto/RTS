using UnityEngine;
using System.Collections;

public class ControlarCamara : MonoBehaviour {

	public float distanciaMinBorde;
	public float velocidadMovimiento;


	void Update(){
		float height = Screen.height;
		float width = Screen.width;

		Vector2 raton = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		float bordeY = height - raton.y;
		float bordeX = width - raton.x;

		Vector3 movimiento = Vector3.zero;

		if(bordeY < distanciaMinBorde){
			movimiento = new Vector3(movimiento.x, movimiento.y, distanciaMinBorde - bordeY);
		}else if(raton.y < distanciaMinBorde){
			movimiento = new Vector3(movimiento.x, movimiento.y, -(distanciaMinBorde - raton.y));
		}

		if(bordeX < distanciaMinBorde){
			movimiento = new Vector3(distanciaMinBorde - bordeX, movimiento.y, movimiento.z);
		}else if(raton.x < distanciaMinBorde){
			movimiento = new Vector3(-(distanciaMinBorde - raton.x), movimiento.y, movimiento.z);
		}

		float movHorizontal = Input.GetAxis("MovHorizontal") * distanciaMinBorde * velocidadMovimiento * 10f;
		float movVertical = Input.GetAxis("MovVertical") * distanciaMinBorde * velocidadMovimiento * 10f;


		movimiento = new Vector3(movimiento.x + movHorizontal, movimiento.y, movimiento.z + movVertical);

		transform.Translate(movimiento * Time.deltaTime * velocidadMovimiento, Space.World);
	}
}

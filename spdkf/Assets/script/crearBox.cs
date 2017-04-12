using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class crearBox : MonoBehaviour {

	public GameObject pj;
	public GameObject box;
	public Vector3 target;
	public GameObject comprobador;
	public LayerMask layers;
	public bool ponerBox;
	public float contador;
	public bool contadorBool;
	public float mag;
	public Vector3 comprobadorPos;


	void Start () {
		
	}
	

	void Update () 
	{
		
		PonerBox ();
		Comprobador ();
		TiempoBox ();



	}

	void PonerBox()
	{
		
		if (ponerBox==true&&Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			contadorBool = true;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100,layers)) 
			{
				target = hit.point;
				comprobadorPos = comprobador.transform.position;
				Destroy (comprobador);

			}
		}

		if (contador >= 3f) 
		{
			Instantiate (box, new Vector3 (Mathf.Round (comprobadorPos.x), comprobadorPos.y, Mathf.Round (comprobadorPos.z)), Quaternion.Euler (0, 0, 0));
			ponerBox = false;
			contador = 0;
			contadorBool = false;
		}
	}

	void Comprobador()
	{
		RaycastHit hit1;

		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit1, 100,layers)) {
			target = hit1.point;
		}
		
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			RaycastHit hit;
			ponerBox = true;


			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100,layers)) {
				target = hit.point;
				comprobador = Instantiate (box, new Vector3(target.x,Mathf.Round (target.y)+ 1.5f,target.z), Quaternion.Euler(0,0,0));

			}
		}
		if (comprobador != null) {
			comprobador.transform.position = new Vector3 (Mathf.Round (target.x),Mathf.Round (target.y)+ 1.5f, Mathf.Round (target.z));
		}
	}
	void TiempoBox()
	{
		
			Vector3 diff = new Vector3(comprobadorPos.x,comprobadorPos.y,comprobadorPos.z) - pj.transform.position;
			mag = diff.magnitude;

			

		if(comprobadorPos != new Vector3(0,0,0))
		{
			if (mag < 4f && contadorBool==true) 
		{
			contador = contador + 1 * Time.deltaTime;
		}
		}
	}
}

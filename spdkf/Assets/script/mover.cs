using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mover : MonoBehaviour {
	
	public  NavMeshAgent agent;
	crearBox magnitud;
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		magnitud = GetComponent<crearBox> ();
	}
	

	void Update () 
	{
		if (Input.GetMouseButtonDown(1)||Input.GetMouseButtonDown(0)) {
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				
				agent.destination = new Vector3 (hit.point.x - 1f, hit.point.y, hit.point.z - 1f);
			}
		}
	}
}

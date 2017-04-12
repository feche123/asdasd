﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCamara : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosX= Input.mousePosition.x;
		float mousePosY= Input.mousePosition.y;
		int scrollDistance = 20;
		float scrollSpeed = 50;

		if (mousePosX < scrollDistance) 
		{
			transform.Translate (Vector3.right * -scrollSpeed * Time.deltaTime);
		}
		if (mousePosX >= Screen.width - scrollDistance) 
		{
			transform.Translate (Vector3.right * scrollSpeed * Time.deltaTime);
		}
		if (mousePosY < scrollDistance) {
			transform.Translate (transform.forward * -scrollSpeed * Time.deltaTime);
		}
		if (mousePosY >= Screen.height - scrollDistance) 
		{
			transform.Translate (transform.forward * scrollSpeed * Time.deltaTime);
		}
		
	}
}

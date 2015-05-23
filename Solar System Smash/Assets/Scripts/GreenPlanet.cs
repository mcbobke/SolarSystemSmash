﻿using UnityEngine;
using System.Collections;

public class GreenPlanet : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("setGreenPlanet");
		//GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");
		
	}
	
	void OnDestroy()
	{
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("setGreenPlanet");
		//GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");
		gameObject.SetActive (false);
		
	}
	
	void OnCollisionEnter2D(Collision2D col)		// SHOULD BE REMOVED AND CALL ONDESTROY WHEN IT IS ACTUALLY DESTROYED
	{
		if (col.gameObject.tag == "Comet") {
			OnDestroy();
			
		}
		if (col.gameObject.tag == "Moon") {
			col.gameObject.SetActive(false);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoonPlayer : MonoBehaviour {

	public Rigidbody2D rb;
	private float speed;
	public static float range = 2;

	// Use this for initialization
	void Start () {

		speed = 250;
		rb = GetComponent<Rigidbody2D>();
	}

	/*void FixedUpdate()
	{
		speed = 10;
		
		// Moves and stops
		rb.velocity = new Vector2 (Mathf.Lerp (0, Input.GetAxis ("Horizontal") * speed, 0.8f),
		                                   Mathf.Lerp (0, Input.GetAxis ("Vertical") * speed, 0.8f));
	}*/

	void Update () {

		//transform.RotateAround (target.position, Vector3.forward, 1);

		if (Input.GetKey (KeyCode.W)) {

			rb.AddForce (Vector2.up * speed * Time.deltaTime);

		}

		if (Input.GetKey (KeyCode.A)) {
			
			rb.AddForce (-1 * Vector2.right * speed * Time.deltaTime);
			
		}

		if (Input.GetKey (KeyCode.S)) {
		
			rb.AddForce (-1 * Vector2.up * speed * Time.deltaTime);
			
		}

		if (Input.GetKey (KeyCode.D)) {
			
			rb.AddForce (Vector2.right * speed * Time.deltaTime);
			
		}

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Comet") {
			//col.gameObject.BroadcastMessage("ApplyDamage", damage);

			CometScript.nearMoon = true;

		}
	}

}

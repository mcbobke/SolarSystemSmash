using UnityEngine;
using System.Collections;

public class GreenPlanet : MonoBehaviour {

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("setGreenPlanet");
	}
	
	void OnDestroy()
	{
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("setGreenPlanet");
		gameObject.SetActive (false);
	}
	
	void OnCollisionEnter2D(Collision2D col)		
	{
		if (col.gameObject.tag == "Moon") {
			col.gameObject.SetActive(false);
			
		}
	}
	
	// Update is called once per frame
	void Update () {

		//rb.AddForce (Vector2.up * 20 * Time.deltaTime);
		
	}
}

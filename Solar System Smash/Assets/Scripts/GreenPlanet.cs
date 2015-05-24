using UnityEngine;
using System.Collections;

public class GreenPlanet : MonoBehaviour {

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

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

		//rb.AddForce (Vector2.up * 20 * Time.deltaTime);
		
	}
}

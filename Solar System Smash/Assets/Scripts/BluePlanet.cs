using UnityEngine;
using System.Collections;

public class BluePlanet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("switchControls");
		//GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");

	}

	void OnDestroy()
	{
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("switchControls");
		//GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");
		gameObject.SetActive (false);

	}

	void OnCollisionEnter2D(Collision2D col)		// SHOULD BE REMOVED AND CALL ONDESTROY WHEN IT IS ACTUALLY DESTROYED
	{
		if (col.gameObject.tag == "Comet") {
			OnDestroy();

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}

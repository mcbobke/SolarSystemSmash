using UnityEngine;
using System.Collections;

public class gainHealthScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Moon") {
			
			col.gameObject.BroadcastMessage("gainHealth");
			//GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("gainHealthSun");
			Destroy(this.gameObject);
			
		}
	}

}

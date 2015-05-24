using UnityEngine;
using System.Collections;

public class ImmunityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Moon") {
			
			col.gameObject.BroadcastMessage("setImmune");
			Destroy(this.gameObject);

		}
	}

}

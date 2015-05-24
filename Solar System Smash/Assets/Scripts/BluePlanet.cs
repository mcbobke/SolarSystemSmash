using UnityEngine;
using System.Collections;

public class BluePlanet : MonoBehaviour {

	private int health = 10;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("switchControls");
		GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");

	}

	void reduceHealth()
	{
		health -= 1;
	}
	
	// Update is called once per frame
	void Update () {

		if(health == 0)
		{
			Destroy(this.gameObject);
			GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("switchControls");
			GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");

		}
	
	}

	void OnCollisionEnter2D(Collision2D col)		
	{

		if (col.gameObject.name == "Projectile(Clone)") {
			
			health--;
			
		}
	}
}

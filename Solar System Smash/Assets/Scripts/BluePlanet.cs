using UnityEngine;
using System.Collections;

public class BluePlanet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("switchControls");
		GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");

	}

	void OnDestroy()
	{
		GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("switchControls");
		GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("flipInput");
		gameObject.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
	
	}
}

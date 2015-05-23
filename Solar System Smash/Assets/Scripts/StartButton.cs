using UnityEngine;
using System.Collections;

public class StartButton: MonoBehaviour {
	//public Renderer rend;
    public GameObject myVisible;

	void Start() {
		//rend = GetComponent<Renderer>();
        myVisible.SetActive(false);
	}

	void OnMouseEnter()
	{
        myVisible.SetActive(true); 
	}

	void OnMouseExit() {
        myVisible.SetActive(false);
	}

    void OnMouseDown() {
		Application.LoadLevel("main");
	}

}

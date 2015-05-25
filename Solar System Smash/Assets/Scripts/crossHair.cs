using UnityEngine;
using System.Collections;

public class crossHair : MonoBehaviour {

	public Texture2D crosshairImage;
	public Rect position;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);

		position = new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height);
	}

	void onGUI()
	{
		GUI.DrawTexture (position, crosshairImage);
	}
}

using UnityEngine;
using System.Collections;

public class MenuSun : MonoBehaviour {
    //edit these values to put in 
    float maxupanddown = 1;
    float speed = 60;
    float angle = 0;
    float todegrees = Mathf.PI/180;
    public Vector3 localPosition;

    void Start ()
    {
        localPosition = GetComponent<Transform>().position;
    }

	// Update is called once per frame
	void Update () {
        angle += speed * Time.deltaTime;


        if (angle > 360) angle -= 360;
        localPosition.y = maxupanddown * Mathf.Sin(angle * todegrees);
        GetComponent<Transform>().position = localPosition;
	}

}

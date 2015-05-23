using UnityEngine;
using System.Collections;

public class MenuMoon : MonoBehaviour {

    //edit these values for maximum floating positions, speed and interpolation
    float maxupanddown = -1;
    float speed = 100;
    float angle = 0;
    float todegrees = Mathf.PI / 180;
    public Vector3 localPosition;

    void Start()
    {
        localPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;


        if (angle > 360) angle -= 360;
        localPosition.y = maxupanddown * Mathf.Sin(angle * todegrees);
        GetComponent<Transform>().position = localPosition;
    }
}

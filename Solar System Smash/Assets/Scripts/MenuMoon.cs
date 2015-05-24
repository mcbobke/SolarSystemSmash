using UnityEngine;
using System.Collections;

public class MenuMoon : MonoBehaviour
{
    //edit these values for maximum floating positions, speed and interpolation
    private float maxupanddown = -1;
    private float speed = 100;
    private float angle = 0;
    private float todegrees = Mathf.PI/180;
    public Vector3 localPosition;

    private void Start()
    {
        localPosition = GetComponent<Transform>().position;
    }

    private void Update()
    {
        angle += speed*Time.deltaTime;


        if (angle > 360) angle -= 360;
        localPosition.y = maxupanddown*Mathf.Sin(angle*todegrees);
        GetComponent<Transform>().position = localPosition;
    }
}

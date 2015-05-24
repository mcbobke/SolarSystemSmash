using UnityEngine;
using System.Collections;

public class MenuSun : MonoBehaviour
{
    //edit these values to put in 
    private float maxupanddown = 1;
    private float speed = 100;
    private float angle = 0;
    private float todegrees = Mathf.PI/180;
    public Vector3 localPosition;

    private void Start()
    {
        localPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    private void Update()
    {
        angle += speed*Time.deltaTime;


        if (angle > 360) angle -= 360;
        localPosition.y = maxupanddown*Mathf.Sin(angle*todegrees);
        GetComponent<Transform>().position = localPosition;
    }
}

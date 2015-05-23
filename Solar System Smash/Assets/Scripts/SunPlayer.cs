using UnityEngine;
using System.Collections;

public class SunPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movement = new Vector2(0f, 5f);

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 5)
            rb.AddForce(movement);
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -5)
            rb.AddForce(-movement);
    }
}

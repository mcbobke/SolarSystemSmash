using UnityEngine;
using System.Collections;

public class SunPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool inputFlipped;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0f, 5f);
        inputFlipped = false;
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

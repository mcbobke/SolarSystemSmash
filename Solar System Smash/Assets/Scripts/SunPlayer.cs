using UnityEngine;
using System.Collections;

public class SunPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
<<<<<<< HEAD
    private Vector2 movement = new Vector2(0f, 10f);
=======
    private Vector2 movement = new Vector2(0f, 5f);
>>>>>>> parent of 134c356... Colliders, colliders, colliders

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(movement);
    }
}

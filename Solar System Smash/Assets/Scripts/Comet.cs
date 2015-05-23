using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour
{
    Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        // TODO: decrement shared player health or something
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // TODO: if other was with left side of screen, decrement shared player health or something; destroy object
        //       if other was with the sun, just destroy object; increment something?
        //       if other was with the moon, decrement moon health, destroy object

        if (other.gameObject.tag == "LeftBoundary")
        {
            Debug.Log("Comet passed the sun.");
            // Decrement shared player health or something
            Destroy(this.gameObject); 
        }
        else if (other.gameObject.name == "Moon")
        {
            // Decrement moon health
            Destroy(this.gameObject); 
        }
        else if (other.gameObject.tag != "Comet") 
        {
            Destroy(this.gameObject); 
        }
    }
}

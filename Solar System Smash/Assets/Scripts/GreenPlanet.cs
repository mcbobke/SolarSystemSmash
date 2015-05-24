using UnityEngine;
using System.Collections;

public class GreenPlanet : MonoBehaviour
{
    private Rigidbody2D rb;
    private int health = 10;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject.FindGameObjectWithTag("Moon").BroadcastMessage("setGreenPlanet");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Moon")
        {
            GameObject.FindGameObjectWithTag("Moon").BroadcastMessage("greenPlanetKill");
            col.gameObject.SetActive(false);
        }

        if (col.gameObject.name == "Projectile(Clone)")
        {
            health--;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Moon").BroadcastMessage("setGreenPlanet");
        }
        //rb.AddForce (Vector2.up * 20 * Time.deltaTime);
    }
}

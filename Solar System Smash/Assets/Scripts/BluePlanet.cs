using UnityEngine;
using System.Collections;

public class BluePlanet : MonoBehaviour
{
    private int health = 10;

    // Use this for initialization
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Moon").BroadcastMessage("switchControls");
        GameObject.FindGameObjectWithTag("Sun").BroadcastMessage("flipInput");
    }

    private void reduceHealth()
    {
        health -= 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (health == 0)
        {
            //GameObject.Find("GameManager").
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Moon").BroadcastMessage("switchControls");
            GameObject.FindGameObjectWithTag("Sun").BroadcastMessage("flipInput");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Projectile(Clone)")
        {
            health--;
			Destroy(col.gameObject);
        }
    }
}

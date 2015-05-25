using UnityEngine;
using System.Collections;

public class BluePlanet : MonoBehaviour
{
    public bool hasSpawned = false;
    private int count = 1;
    private int health = 10;

    // Use this for initialization
    private void Start()
    {
    }

    private void reduceHealth()
    {
        health -= 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasSpawned && count == 1)
        {
            GameObject.FindGameObjectWithTag("Moon").BroadcastMessage("switchControls");
            GameObject.FindGameObjectWithTag("Sun").BroadcastMessage("flipInput");
            count++;
        }

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

		if (col.gameObject.tag == "Moon") {
			GameObject.FindGameObjectWithTag ("Moon").BroadcastMessage("bluePlanetDamage");

		}
    }
}

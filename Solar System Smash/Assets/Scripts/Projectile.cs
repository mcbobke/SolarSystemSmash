using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private float timeAlive;

    private void Start()
    {
        timeAlive = 0f;
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > 3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Comet")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}

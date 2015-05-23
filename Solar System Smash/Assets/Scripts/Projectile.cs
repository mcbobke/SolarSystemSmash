using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    private void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Comet")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}

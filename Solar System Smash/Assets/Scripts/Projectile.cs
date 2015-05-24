using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Comet")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}

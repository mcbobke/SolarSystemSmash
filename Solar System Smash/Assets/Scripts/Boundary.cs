using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Projectile" || coll.gameObject.tag == "Comet")
            Destroy(coll.gameObject);
    }
}

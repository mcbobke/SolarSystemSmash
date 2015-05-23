using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag + coll.gameObject.name);
        Debug.Log("this is working");
        if (coll.gameObject.tag == "Projectile")
            Destroy(coll.gameObject);
    }
}

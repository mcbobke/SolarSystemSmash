using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour
{
    private void OnCollsionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "Projectile")
            Destroy(coll.gameObject);
    }
}

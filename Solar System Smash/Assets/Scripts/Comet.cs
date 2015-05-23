using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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

    void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class rotateScript : MonoBehaviour {

	public static Vector3 offset;
	private Rigidbody2D rb;							// NISH

	// Use this for initialization
	void Start () {

		offset = transform.position - transform.parent.position;
		rb = GetComponent<Rigidbody2D> ();			// NISH

	}
	
	// Update is called once per frame
	void Update () {

	
		/*if((transform.position-transform.parent.position).sqrMagnitude > offset.sqrMagnitude + 1)
		{
			Debug.Log ("hey");
			rb.AddForce((transform.parent.position - transform.position) * 30 * Time.deltaTime); // NOT REALLY NECESSARY
			//transform.position = target.transform.position + offset;
		}

		transform.RotateAround (transform.parent.position, Vector3.forward, 4);*/
	
	}
}

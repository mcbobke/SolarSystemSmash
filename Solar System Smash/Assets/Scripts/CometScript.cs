using UnityEngine;
using System.Collections;

public class CometScript : MonoBehaviour {
	
	private bool nearMoon = false;
	public Transform target;
	private Vector3 offset;
	private int count = 1;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
	}

	void setNearMoon()
	{
		nearMoon = true;
	}

	// Update is called once per frame
	void Update () {
		
		if (!nearMoon) {
			
		} else {
			
			if(count == 1)
			{
				offset = transform.position - target.transform.position; // MORE ACCURATE
				count++;
			}
			
			//rb.AddForce((target.transform.position - transform.position) * 100 * Time.deltaTime);
			
			//transform.position = target.transform.position + offset;
			transform.RotateAround (target.transform.position, Vector3.forward, 5);
			
		}
		
	}
}

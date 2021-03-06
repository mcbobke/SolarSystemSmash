﻿using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour
{
	private bool nearMoon = false; 			// NISH
	//private Transform target;						// NISH
	private Rigidbody2D rb;							// NISH
	private int count = 1;	
	private Vector3 offset;

    public SpriteRenderer spriteRender;
    public Sprite[] spriteList = new Sprite[8];

	void setNearMoon()
	{
		if (!nearMoon) {
			nearMoon = true;
			MoonPlayer.cometCount++;
			transform.parent = GameObject.FindGameObjectWithTag("Moon").transform;
		}
	}
	
	/*void ignoreCollisions()
	{
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag ("Moon").GetComponent<Collider2D>(),GetComponent<Collider2D>(),true);
	}*/

    // Use this for initialization
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        int index = (int)Random.Range(1, 8);
        spriteRender.sprite = spriteList[index];
        //target = GameObject.Find("cartoon-moon").transform;

		rb = GetComponent<Rigidbody2D> ();			// NISH
    }

    // Update is called once per frame
    void Update()
    {
		if (nearMoon) {

			if(count == 1)
			{
				offset = transform.position - transform.parent.position;
				count++;
			}
		
			if((transform.parent.position-transform.position).sqrMagnitude > offset.sqrMagnitude + 1)
			{
				//Debug.Log ("hey");
				rb.AddForce((transform.parent.position - transform.position) * 30 * Time.deltaTime); // NOT REALLY NECESSARY
				//transform.position = target.transform.position + offset;
			}
			transform.RotateAround (transform.parent.position, Vector3.forward, 4);


			/*if(count == 1)
			{
				offset = transform.position - target.transform.position;
				count++;
			}

			if((transform.position-target.transform.position).sqrMagnitude > offset.sqrMagnitude + 4)
			{
				rb.AddForce((target.transform.position - transform.position) * 30 * Time.deltaTime); // NOT REALLY NECESSARY
				//transform.position = target.transform.position + offset;
			}
			transform.RotateAround (target.transform.position, Vector3.forward, 4);
			*/
		}
    }

    void OnBecameInvisible()
    {
        // TODO: decrement shared player health or something
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // TODO: if other was with left side of screen, decrement shared player health or something; destroy object
        //       if other was with the sun, just destroy object; increment something?
        //       if other was with the moon, decrement moon health, destroy object

        if (other.gameObject.tag == "LeftBoundary")
        {
			GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("reduceHealth");
			if(transform.parent != null && transform.parent.tag == "Moon")
			{
				MoonPlayer.cometCount--;
			}
            // Decrement shared player health or something
            Destroy(this.gameObject); 
        }
		else if (other.gameObject.tag != "Comet" && other.gameObject.tag != "Moon" && other.gameObject.tag != "Planet") 
		{
			if(transform.parent != null && transform.parent.tag == "Moon")
			{
				MoonPlayer.cometCount--;
			}
            Destroy(this.gameObject); 
        }
    }
}

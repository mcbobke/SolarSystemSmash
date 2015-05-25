using UnityEngine;
using System.Collections;

public class ImmunityScript : MonoBehaviour {

	private Renderer r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer> ();
		StartCoroutine (Blink ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator Blink()
	{
		while(true)
		{
			r.enabled = false;
			yield return new WaitForSeconds(0.3f);
			r.enabled = true;
			yield return new WaitForSeconds(0.3f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Moon") {
			
			col.gameObject.BroadcastMessage("setImmune");
			GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("setImmuneSun");
			Destroy(this.gameObject);

		}
	}

}

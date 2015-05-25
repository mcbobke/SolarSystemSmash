using UnityEngine;
using System.Collections;

public class gainHealthScript : MonoBehaviour {

    public SoundEffectPlayer soundEffectPlayer;
	private Renderer r;

	// Use this for initialization
	void Start () {
	
		r = GetComponent<Renderer> ();
		StartCoroutine (Blink ());
	}
	
	// Update is called once per frame
	void Update () {



		//InvokeRepeating("Blink", 0, 0.4);
	
	}


	
	public IEnumerator Blink()
	{
		while(true)
		{
			r.enabled = false;
			yield return new WaitForSeconds(0.2f);
			r.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Moon") {
            soundEffectPlayer.PlaySoundEffect("get_health", 0.5f);
			col.gameObject.BroadcastMessage("gainHealth");
			GameObject.FindGameObjectWithTag ("Sun").BroadcastMessage("gainHealthSun");
            this.gameObject.SetActive(false);			
		}
	}

}

using UnityEngine;
using System.Collections;     

public class CometSpawner : MonoBehaviour {

    public GameObject cometPrefab;

    // Arguments to control the difficulty of the comet spawns
    //public float spawnRate;
    //public float directionVariation;
    //public float speedVariation;

    private const float SCREEN_RIGHT = 9.0f;

    private float bulletYcoord;
    private double nextSpawnTime;
    private float xspeed;
    private float yspeed = 0.0f;

    private int fireCount = 0;      // Debug variable to keep Update() from continuously calling FireComet()

	// Use this for initialization
	void Start () 
    {
        bulletYcoord = Random.Range(-4.9f, 5.0f);
        xspeed = Random.Range(10.0f, 100.0f);
        Debug.Log("bulletYcoord = " + bulletYcoord + ", xspeed = " + xspeed);
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Temporary test
        if (fireCount < 6)
        {
            FireComet();
            fireCount++;
            bulletYcoord = Random.Range(-4.9f, 5.0f);
            xspeed = Random.Range(60.0f, 200.0f);
            Debug.Log("bulletYcoord = " + bulletYcoord + ", xspeed = " + xspeed);
        }
	}

    void FireComet ()
    {
        GameObject clone;

        clone = (Instantiate(cometPrefab, new Vector3(SCREEN_RIGHT, bulletYcoord, 0.0f), transform.rotation)) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xspeed, yspeed));

    }

}

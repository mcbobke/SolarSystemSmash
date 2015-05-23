using UnityEngine;
// using System;
using System.Collections;

public class CometSpawner : MonoBehaviour
{
    // Arguments to control the difficulty of the comet spawns
    //public float spawnRate;
    //public float directionVariation;
    //public float speedVariation;

    public const float XSPEED_MAX = 200.0f;

    private const float SCREEN_RIGHT = 9.0f;
    private const float SCREEN_LENGTH = 9.0f;
    private const float SCREEN_HEIGHT = 5.0f;

    public GameObject cometPrefab;
    public float ySpeedScaling = 50.0f;

    private float currentTime;
    private float nextSpawnTime;

    private float xSpeed;
    private float ySpeed;
    private float startingYcoord;
    private int yDirection;
    private float ySpeedMax;     

    private System.Random rand;     // Necessary? Only used to figure out yDirection

    // Use this for initialization
    void Start()
    {
        rand = new System.Random();
        currentTime = Time.fixedTime;
        nextSpawnTime = currentTime + Random.Range(0.5f, 1.0f);

        GenerateNewCometValues();        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.fixedTime;

        if (currentTime >= nextSpawnTime)
        {
            FireComet();
            nextSpawnTime += + Random.Range(0.5f, 1.0f);
            Debug.Log("nextSpawnTime " + nextSpawnTime);
        }

        //// Temp test
        //if (fireCount < 6)
        //{
        //    FireComet();
        //    fireCount++;
        //}
    }

    void FireComet()
    {
        GenerateNewCometValues();

        GameObject Clone;

        Clone = (Instantiate(cometPrefab, new Vector3(SCREEN_RIGHT, startingYcoord, 0.0f), transform.rotation)) as GameObject;
        Clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xSpeed, ySpeed));
        Debug.Log("Spawned a comet with starting coordinate: "+startingYcoord+", xSpeed "+xSpeed+", ySpeed "+ySpeed);
    }

    void GenerateNewCometValues()
    {
        xSpeed = Random.Range(50.0f, XSPEED_MAX);

        startingYcoord = Random.Range(-4.8f, 4.8f);
        yDirection = (rand.Next(2) == 0) ? 1 : -1;      // Determines the sign for ySpeed
        ySpeedMax = ((yDirection * (SCREEN_HEIGHT - 0.1f) - startingYcoord) / SCREEN_LENGTH) * ySpeedScaling;
        ySpeed = Random.Range(5.0f, ySpeedMax);
    }

}

using UnityEngine;
// using System;
using System.Collections;

public class CometSpawner : MonoBehaviour
{
    // Arguments to control the difficulty of the comet spawns

    private const float SCREEN_RIGHT = 9.0f;
    private const float SCREEN_LENGTH = 9.0f;
    private const float SCREEN_HEIGHT = 5.0f;

    public GameObject cometPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateRange = 0.5f;
    public float xSpeedMin = 50.0f;
    public float xSpeedMax = 100.0f;
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
        nextSpawnTime = currentTime + Random.Range(spawnRateMin, spawnRateMin + spawnRateRange);

        GenerateNewCometValues();        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.fixedTime;

        if (currentTime >= nextSpawnTime)
        {
            FireComet();
            nextSpawnTime += Random.Range(spawnRateMin, spawnRateMin + spawnRateRange);
            // Debug.Log("nextSpawnTime " + nextSpawnTime);
        }

    }

    void FireComet()
    {
        GenerateNewCometValues();

        GameObject Clone;

        // 0.3f is an offset that keeps the comet's CircleCollider from colliding with the right side of the screen at spawn
        Clone = (Instantiate(cometPrefab, new Vector3(SCREEN_RIGHT - 0.3f, startingYcoord, 0.0f), transform.rotation)) as GameObject;
        Clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xSpeed, ySpeed));
        // Debug.Log("Spawned a comet with starting coordinate: "+startingYcoord+", xSpeed "+xSpeed+", ySpeed "+ySpeed);
    }

    void GenerateNewCometValues()
    {
        xSpeed = Random.Range(xSpeedMin, xSpeedMax);

        startingYcoord = Random.Range(-4.8f, 4.8f);
        yDirection = (rand.Next(2) == 0) ? 1 : -1;      // Determines the sign for ySpeed

        // 0.4f is an offset that's supposed to prevent most comets from going off screen before they get to left side
        ySpeedMax = ((yDirection * (SCREEN_HEIGHT - 0.4f) - startingYcoord) / SCREEN_LENGTH) * ySpeedScaling;
        ySpeed = Random.Range(0.0f, ySpeedMax);
    }

}

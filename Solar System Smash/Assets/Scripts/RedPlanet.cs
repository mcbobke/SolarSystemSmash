using System;
using UnityEngine;
using System.Collections;

public class RedPlanet : MonoBehaviour
{
    private float timeSinceLastMovementChange;
    private float timeSinceLastAddForce;
    private float timeSinceLastFire;
    private Rigidbody2D rb;
    private Vector2 movement;
    private GameObject[] targets;

    public float maxTimeSinceLastMovementChange;
    public float maxTimeSinceLastAddForce;
    public float maxMovementSpeed;
    public float maxTimeSinceLastFire;
    public int health;
    public GameObject projPrefab;
    public GameObject projSpawnPoint;

    private void Start()
    {
        timeSinceLastMovementChange = 0f;
        timeSinceLastAddForce = 0f;
        timeSinceLastFire = 0f;
        rb = GetComponent<Rigidbody2D>();
        targets = new GameObject[2];
        targets[0] = GameObject.Find("cartoon-moon");
        targets[1] = GameObject.Find("Sun");

        float moveX, moveY;

        do
        {
            moveX = UnityEngine.Random.Range(-maxMovementSpeed, maxMovementSpeed);
            moveY = UnityEngine.Random.Range(-maxMovementSpeed, maxMovementSpeed);
        } while (moveX < 75 && moveY < 75);
        

        movement = new Vector2(moveX, moveY);

        rb.AddForce(movement);
    }

    private void Update()
    {
        timeSinceLastMovementChange += Time.deltaTime;
        timeSinceLastAddForce += Time.deltaTime;
        timeSinceLastFire += Time.deltaTime;

        if (timeSinceLastMovementChange >= maxTimeSinceLastMovementChange)
        {
            ChangeMovement();
            timeSinceLastMovementChange = 0f;
            timeSinceLastAddForce = 0f;

            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(movement);
        }

        else if (timeSinceLastAddForce >= maxTimeSinceLastAddForce)
        {
            timeSinceLastAddForce = 0f;
            rb.AddForce(movement);
        }

        if ((transform.position.x <= -5f && movement.x < 0) || (transform.position.x >= 8f && movement.x > 0))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            movement = new Vector2(-movement.x, movement.y);
            timeSinceLastAddForce = 0f;
            timeSinceLastMovementChange = 0f;
        }

        if ((transform.position.y >= 4f && movement.y > 0) || (transform.position.y <= -4f && movement.y < 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            movement = new Vector2(movement.x, -movement.y);
            timeSinceLastAddForce = 0f;
            timeSinceLastMovementChange = 0f;
        }

        if (timeSinceLastFire >= maxTimeSinceLastFire)
        {
            timeSinceLastFire = 0f;
            Fire();
        }
    }

    private void ChangeMovement()
    {
        float moveX, moveY;

        do
        {
            moveX = UnityEngine.Random.Range(-maxMovementSpeed, maxMovementSpeed);
            moveY = UnityEngine.Random.Range(-maxMovementSpeed, maxMovementSpeed);
        } while (moveX < 75 && moveY < 75);

        movement = new Vector2(moveX, moveY);
    }

    private void Fire()
    {
        GameObject chosenTarget = targets[UnityEngine.Random.Range(0, targets.Length)];

        Vector3 diff = chosenTarget.transform.position - transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        GameObject newProj = (GameObject)Instantiate(projPrefab, projSpawnPoint.transform.position, rotation);

        Physics2D.IgnoreCollision(newProj.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        newProj.GetComponent<Rigidbody2D>().AddForce(newProj.transform.up * 500f);
    }
}

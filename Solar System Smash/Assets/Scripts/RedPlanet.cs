using System;
using UnityEngine;
using System.Collections;

public class RedPlanet : MonoBehaviour
{
    private float timeSinceLastFire;
    private GameObject moon;
    private Rigidbody2D rb;

    public float maxTimeSinceLastFire;
    public int health;
    public GameObject projPrefab;
    public GameObject projSpawnPoint;
    public float movementSpeed;

    private void Start()
    {
        timeSinceLastFire = 0f;
        moon = GameObject.Find("cartoon-moon");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        if (timeSinceLastFire >= maxTimeSinceLastFire)
        {
            timeSinceLastFire = 0f;
            Fire();
        }

        Vector3 diff = moon.transform.position - transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        rb.AddForce(new Vector2(diff.x, diff.y));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Projectile")
        {
            --health;
            if (health <= 0)
                Destroy(gameObject);
        }
    }

    private void Fire()
    {
        Vector3 diff = moon.transform.position - transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        GameObject newProj = (GameObject)Instantiate(projPrefab, projSpawnPoint.transform.position, rotation);

        Physics2D.IgnoreCollision(newProj.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        newProj.GetComponent<Rigidbody2D>().AddForce(newProj.transform.up * 500f);
    }
}

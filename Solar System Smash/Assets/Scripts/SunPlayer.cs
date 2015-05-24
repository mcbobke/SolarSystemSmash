using UnityEngine;
using System.Collections;

public class SunPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool inputFlipped;
    private Vector3 mousePosition;
    private Vector3 startPosition;

    public GameObject projPrefab;
    public GameObject projSpawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0f, 5f);
        inputFlipped = false;
        mousePosition = Input.mousePosition;
        startPosition = transform.position;
    }

	public void flipInput()
	{
		inputFlipped = !inputFlipped;
	}

    private void Update()
    {
        // Input for movement
        if (!inputFlipped)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rb.AddForce(movement);
            else if (Input.GetKey(KeyCode.DownArrow))
                rb.AddForce(-movement);
        }

        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rb.AddForce(-movement);
            else if (Input.GetKey(KeyCode.DownArrow))
                rb.AddForce(movement);
        }

        // Getting mouse position and then making sure that the sun faces the mouse with it's "up" vector
        mousePosition = Input.mousePosition;

        Vector3 diff = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        // Fire
        if (Input.GetMouseButtonDown(0))
            Fire(mousePosition);

        // Ensure that the x position of the sun is the same as the start
        if (transform.position.x != startPosition.x)
            transform.position = new Vector3(startPosition.x, transform.position.y);

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Comet")
        {
            Destroy(coll.gameObject);
        }
    }

    private void Fire(Vector3 mousePosition)
    {
        Quaternion projRotation = transform.rotation;
        GameObject proj = (GameObject)Instantiate(projPrefab, projSpawnPoint.transform.position, projRotation);
        proj.GetComponent<Rigidbody2D>().AddForce(proj.transform.up * 500f);
    }
}

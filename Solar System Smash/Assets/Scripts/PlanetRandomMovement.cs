using UnityEngine;
using System.Collections;

public class PlanetRandomMovement : MonoBehaviour
{
    private float timeSinceLastMovementChange;
    private float timeSinceLastAddForce;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isActive;

    public float maxTimeSinceLastMovementChange;
    public float maxTimeSinceLastAddForce;
    public float maxMovementSpeed;

    private void Start()
    {
        timeSinceLastMovementChange = 0f;
        timeSinceLastAddForce = 0f;
        rb = GetComponent<Rigidbody2D>();
        isActive = false;

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
        if (isActive)
        {
            timeSinceLastMovementChange += Time.deltaTime;
            timeSinceLastAddForce += Time.deltaTime;

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

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
}

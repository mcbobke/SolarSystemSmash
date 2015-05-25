using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SunPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool inputFlipped;
    private Vector3 mousePosition;
    private Vector3 startPosition;
    private float timer = 10;
    private bool inputFlipState;
    private bool immunityOff;
    private float timebetweenshot;
    private bool redPlanetSpawned;


    public GameObject projPrefab;
    public GameObject projSpawnPoint;
    public Slider healthBarSlider; //health bar slider reference

    public SoundEffectPlayer soundEffectPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0f, 5f);
        mousePosition = Input.mousePosition;
        startPosition = transform.position;
        inputFlipped = false;
        inputFlipState = inputFlipped;
        immunityOff = false;
        redPlanetSpawned = false;
    }

    public void setImmuneSun()
    {
        inputFlipped = false;
        timer = 10;
        immunityOff = false;
    }

    private void gainHealthSun()
    {
        if (healthBarSlider.value > 0 && healthBarSlider.value < healthBarSlider.maxValue)
        {
            healthBarSlider.value += 0.4f;
        }
    }

    private void reduceHealth()
    {
        healthBarSlider.value -= .2f; //reduce health
    }

    public void flipInput()
    {
        inputFlipped = !inputFlipped;
        inputFlipState = inputFlipped;
    }

    private void Update()
    {
        timebetweenshot += Time.deltaTime;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            if (!immunityOff)
            {
                soundEffectPlayer.PlaySoundEffect("stop_immune", 0.5f);
                inputFlipped = inputFlipState;
                immunityOff = true;
            }
        }

        if (healthBarSlider.value <= 0)
        {
            // go to game over scene

            Debug.Log("Sun - Game Over");
        }

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

        float rotZ = Mathf.Atan2(diff.y, diff.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        // Fire
        if (Input.GetMouseButtonDown(0) && timebetweenshot > 0.5f)
        {
            Fire(mousePosition);
            timebetweenshot = 0f;
        }
        // Ensure that the x position of the sun is the same as the start
        if (transform.position.x != startPosition.x)
            transform.position = new Vector3(startPosition.x, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Comet") // && healthBarSlider.value > 0)
        {
            Destroy(coll.gameObject);
            //healthBarSlider.value -= .2f;  //reduce health
        }
        //  elseif() // for alleged game over screen 
        //    {

        //   }
    }

    private void Fire(Vector3 mousePosition)
    {
        Quaternion projRotation = transform.rotation;
        GameObject proj = (GameObject) Instantiate(projPrefab, projSpawnPoint.transform.position, projRotation);

        if (!redPlanetSpawned)
        {
            proj.GetComponent<Rigidbody2D>().AddForce(proj.transform.up*10f);
        }

        else
        {
            proj.GetComponent<Rigidbody2D>().AddForce(proj.transform.up*1f);
        }

        soundEffectPlayer.PlaySoundEffect("sun_shoot", 0.5f);
    }

    public bool RedPlanetSpawned
    {
        get { return redPlanetSpawned; }

        set { redPlanetSpawned = value; }
    }
}

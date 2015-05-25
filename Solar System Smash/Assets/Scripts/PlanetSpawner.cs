using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetSpawner : MonoBehaviour {

    /* In each list, the indexes correspond to these planets:
     * 0 is Zorgna, Red
     * 1 is Toklar, Green
     * 2 is S'vatcha, Blue
     */

    public CometSpawner cometSpawner;
    public GameObject[] messageList = new GameObject[3];

    private const float SCREEN_RIGHT = 9.0f;
    private const float SCREEN_LENGTH = 18.0f;
    private const float SCREEN_HEIGHT = 5.0f;
    private const float LENGTH_TEXT_ON_SCREEN = 5.32f;
    private bool planetIsMoving = false;
    private GameObject message;

    public RedPlanet zorgna;
    public GreenPlanet toklar;
    public BluePlanet svatcha;

    public gainHealthScript healthPowerup;
    public ImmunityScript immunePowerup;

    private ImmunityScript iPowerup;
    private gainHealthScript hPowerup;

	// Use this for initialization
	void Start () {
        zorgna = Instantiate(zorgna, new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as RedPlanet;
        zorgna.gameObject.SetActive(false);
        toklar.gameObject.SetActive(false);
        svatcha.gameObject.SetActive(false);

	}

    public void SpawnPlanet(int index)
    {
        hPowerup = Instantiate(healthPowerup, new Vector3(Random.Range(-7.0f, 0.0f), Random.Range(-4.0f, 4.0f), 0), new Quaternion(0, 0, 0, 0)) as gainHealthScript;
        iPowerup = Instantiate(immunePowerup, new Vector3(Random.Range(-7f, 0f), Random.Range(-4f, 4f), 0), new Quaternion(0, 0, 0, 0)) as ImmunityScript;

        switch (index)
        {
            case 0:
                zorgna.gameObject.SetActive(true);
                break;
            case 1:
                toklar.gameObject.SetActive(true);
                break;
            case 2:
                svatcha.gameObject.SetActive(true);
                break;
        }
        message = Instantiate(messageList[index], new Vector3(SCREEN_RIGHT + 2.76f, -9.0f, 1), new Quaternion(0, 0, 0, 0)) as GameObject;
        
        switch (index)
        {
            case 0:
                SpawnRedPlanet();
                break;
            case 1:
                SpawnGreenPlanet();
                break;
            case 2:
                SpawnBluePlanet();
                break;
        }

    }

    private void SpawnRedPlanet()
    {
        zorgna.IsActive = false;
        zorgna.GetComponent<Collider2D>().enabled = false;
        StartCoroutine(MoveRedPlanetOnScreen());
        StartCoroutine(reenableRedPlanet());
    }

    private void SpawnGreenPlanet()
    {
        GreenPlanet.isActive = false;
        toklar.GetComponent<Collider2D>().enabled = false;
        StartCoroutine(MoveGreenPlanetOnScreen());
        StartCoroutine(reenableGreenPlanet());
    }

    private void SpawnBluePlanet()
    {
        svatcha.GetComponent<BluePlanet>().enabled = false;
        svatcha.hasSpawned = true;
        svatcha.GetComponent<Collider2D>().enabled = false;
        StartCoroutine(MoveBluePlanetOnScreen());
        StartCoroutine(reenableBluePlanet());
    }

    /*-----------------------------------------------------*/

    private IEnumerator reenableRedPlanet()
    {
        while (planetIsMoving)
        {
            yield return null;
        }
        zorgna.IsActive = true;
        zorgna.GetComponent<Collider2D>().enabled = true;
        //hPowerup.gameObject.SetActive(false);
        //iPowerup.gameObject.SetActive(false);
        Destroy(hPowerup.gameObject);
        Destroy(iPowerup.gameObject);
    }

    private IEnumerator reenableGreenPlanet()
    {
        while (planetIsMoving)
        {
            yield return null;
        }
        GreenPlanet.isActive = true;
        toklar.GetComponent<PlanetRandomMovement>().IsActive = true;
        toklar.GetComponent<Collider2D>().enabled = true;
        //hPowerup.gameObject.SetActive(false);
        //iPowerup.gameObject.SetActive(false);
        Destroy(hPowerup.gameObject);
        Destroy(iPowerup.gameObject);

    }

    private IEnumerator reenableBluePlanet()
    {
        while (planetIsMoving)
        {
            yield return null;
        }
        svatcha.GetComponent<PlanetRandomMovement>().IsActive = true;
        svatcha.GetComponent<BluePlanet>().enabled = true;
        svatcha.GetComponent<Collider2D>().enabled = true;
        //hPowerup.gameObject.SetActive(false);
        //iPowerup.gameObject.SetActive(false);
        Destroy(hPowerup.gameObject);
        Destroy(iPowerup.gameObject);

    }

    /*-----------------------------------------------------*/

    private IEnumerator MoveRedPlanetOnScreen()
    {
        planetIsMoving = true;
        yield return new WaitForSeconds(0.2f);
        while (zorgna.transform.position.x > 2.0f)
        {
            zorgna.transform.position += new Vector3(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.5f);
        planetIsMoving = false;
    }

    private IEnumerator MoveGreenPlanetOnScreen()
    {
        planetIsMoving = true;
        yield return new WaitForSeconds(0.2f);
        while (toklar.transform.position.x > 2.0f)
        {
            toklar.transform.position += new Vector3(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.5f);
        planetIsMoving = false;
    }

    private IEnumerator MoveBluePlanetOnScreen()
    {
        planetIsMoving = true;
        yield return new WaitForSeconds(0.2f);
        while (svatcha.transform.position.x > 2.0f)
        {
            svatcha.transform.position += new Vector3(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.5f);
        planetIsMoving = false;
    }

}

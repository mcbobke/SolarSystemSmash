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

    public RedPlanet zorgna;
    public GreenPlanet toklar;
    public BluePlanet svatcha;

	// Use this for initialization
	void Start () {
        zorgna = Instantiate(zorgna, new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as RedPlanet;
        zorgna.gameObject.SetActive(false);
        //toklar = Instantiate(toklar, new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as GreenPlanet;
        //toklar.gameObject.SetActive(false);
        //svatcha = Instantiate(svatcha, new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as BluePlanet;
        //svatcha.gameObject.SetActive(false);
        SpawnPlanet(0);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SpawnPlanet(int index)
    {
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
        GameObject message = Instantiate(messageList[index], new Vector3(SCREEN_RIGHT + 2.76f, -9.0f, 1), new Quaternion(0, 0, 0, 0)) as GameObject;
        
        cometSpawner.TurnSpawningOff();
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
        //toklar.isActive = false;
        toklar.GetComponent<GreenPlanet>().enabled = false;
        toklar.GetComponent<Collider2D>().enabled = false;
        StartCoroutine(MoveGreenPlanetOnScreen());
        StartCoroutine(reenableGreenPlanet());
    }

    private void SpawnBluePlanet()
    {
        svatcha.GetComponent<PlanetRandomMovement>().IsActive = false;
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
    }

    private IEnumerator reenableGreenPlanet()
    {
        while (planetIsMoving)
        {
            yield return null;
        }
        //toklar.isActive = true;
        toklar.GetComponent<GreenPlanet>().enabled = true;
        toklar.GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator reenableBluePlanet()
    {
        while (planetIsMoving)
        {
            yield return null;
        }
        svatcha.GetComponent<PlanetRandomMovement>().IsActive = true;
        svatcha.GetComponent<Collider2D>().enabled = true;
    }

    /*-----------------------------------------------------*/

    private IEnumerator MoveRedPlanetOnScreen()
    {
        planetIsMoving = true;
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
        while (svatcha.transform.position.x > 2.0f)
        {
            svatcha.transform.position += new Vector3(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.5f);
        planetIsMoving = false;
    }

}

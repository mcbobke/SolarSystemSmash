using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetSpawner : MonoBehaviour {

    /* In each list, the indexes correspond to these planets:
     * 0 is Zorgna
     * 1 is Toklar
     * 2 is S'vatcha
     */

    public CometSpawner cometSpawner;
    public GameObject[] messageList = new GameObject[3];
    public GameObject[] planetList = new GameObject[3];

    private const float SCREEN_RIGHT = 9.0f;
    private const float SCREEN_LENGTH = 18.0f;
    private const float SCREEN_HEIGHT = 5.0f;
    private const float LENGTH_TEXT_ON_SCREEN = 5.32f;
    private bool planetSpawnDelaying = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnPlanet(int index)
    {
        switch (index)
        {
            case 0:
                RedPlanet zorgna = Instantiate(planetList[index], new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as RedPlanet;
                break;
            case 1:
                GreenPlanet toklar = Instantiate(planetList[index], new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as GreenPlanet;
                break;
            case 2:
                BluePlanet svatcha = Instantiate(planetList[index], new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as BluePlanet;
                break;
        }
        GameObject message = Instantiate(messageList[index], new Vector3(SCREEN_RIGHT + 1.76f, SCREEN_HEIGHT / 2, 1), new Quaternion(0, 0, 0, 0)) as GameObject;
        cometSpawner.TurnSpawningOff();
        StartCoroutine(DelayPlanetMove());
        switch (index)
        {
            case 0:
                StartCoroutine(MoveRedPlanetOnScreen());
                break;
            case 1:
                StartCoroutine(MoveGreenPlanetOnScreen());
                break;
            case 2:
                StartCoroutine(MoveBluePlanetOnScreen());
                break;
        }

    }

    private IEnumerator DelayPlanetMove()
    {
        planetSpawnDelaying = true;
        yield return new WaitForSeconds(LENGTH_TEXT_ON_SCREEN);
        planetSpawnDelaying = false;
        
    }

    private IEnumerator MoveRedPlanetOnScreen()
    {
        while (planetSpawnDelaying)
        {
            yield return null;
        }
        // TODO
    }

    private IEnumerator MoveBluePlanetOnScreen()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator MoveGreenPlanetOnScreen()
    {
        throw new System.NotImplementedException();
    }

}

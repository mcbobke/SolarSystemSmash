using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public SunPlayer sun;
    public MoonPlayer moon;
    public CometSpawner cometSpawner;
    public PlanetSpawner planetSpawner;

    private int numCometsDestroyed;
    private int numPlanetsDestroyed;
    private bool planet0Spawned;
    private bool planet1Spawned;
    private bool planet2Spawned;

    private void Start()
    {
        numCometsDestroyed = 0;
    }

    private void Update()
    {
        if (sun.healthBarSlider.value == 0f)
            Application.LoadLevel("loseScene");
        else if (moon.healthBarSliderMoon.value == 0f)
            Application.LoadLevel("loseScene");

        if (numPlanetsDestroyed == 3)
            Application.LoadLevel("Nick's Win Scene");

        if (numCometsDestroyed == 20 && !planet0Spawned)
        {
            SpawnPlanet(0);
            planet0Spawned = true;
        }
            
        else if (numCometsDestroyed == 50 && !planet1Spawned)
        {
            SpawnPlanet(1);
            planet1Spawned = true;
        }
        
        else if (numCometsDestroyed == 90 && !planet2Spawned)
        {
            SpawnPlanet(2);
            planet2Spawned = true;
        }
    }

    public void cometDestroyed()
    {
        numCometsDestroyed += 1;
    }

    private void SpawnPlanet(int index)
    {
        cometSpawner.TurnSpawningOff();

        GameObject[] comets = GameObject.FindGameObjectsWithTag("Comet");
        for (int i = 0; i < comets.Length; ++i)
        {
            Destroy(comets[i]);
        }

        planetSpawner.SpawnPlanet(index);
    }

    public void planetDestroyed()
    {
        numPlanetsDestroyed++;
        cometSpawner.TurnSpawningOn();
    }
}

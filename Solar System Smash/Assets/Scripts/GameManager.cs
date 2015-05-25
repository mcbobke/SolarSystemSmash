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

        if (numCometsDestroyed == 20)
            SpawnPlanet(0);
        else if (numCometsDestroyed == 50)
            SpawnPlanet(1);
        else if (numCometsDestroyed == 90)
            SpawnPlanet(2);
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

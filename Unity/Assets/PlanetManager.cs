using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public int numberOfPlanets = 5; // Set how many planets you want
    public GameObject planetPrefab;  // Assign your planet prefab here (if you have one, or create a new GameObject)

    public Vector3 areaCenter = Vector3.zero; // Area where planets will be placed
    public float areaRadius = 50f;  // Area radius

    void Start()
    {
        CreatePlanets();
    }

    void CreatePlanets()
    {
        for (int i = 0; i < numberOfPlanets; i++)
        {
            Vector3 randomPosition = areaCenter + Random.insideUnitSphere * areaRadius;
            GameObject planetObj = new GameObject("Planet_" + i);  // Create new GameObject for each planet
            planetObj.transform.position = randomPosition;

            Planet planet = planetObj.AddComponent<Planet>();  // Add the Planet script to the new object
            planet.GeneratePlanet();  // Call GeneratePlanet to initialize and generate the planet
        }
    }
}

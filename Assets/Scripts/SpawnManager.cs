using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    [SerializeField]
    private List<Vehicle> vehicles;
    private float minSpawnInterval = 1.2f;
    private float maxSpawnInterval = 4.7f;
    private float spawnPosY = 1;
    private float spawnPosZ = 16;
    private float[] spawnPosX = {-4.5f, -1.75f, 1.5f, 4.5f};

    private List<Coroutine> spawnCoroutines;

    public void Initiate()
    {
        spawnCoroutines = new List<Coroutine>();
        foreach (float xPos in spawnPosX)
        {
            spawnCoroutines.Add(StartCoroutine(RepeatlySpawnVehicle(xPos)));
        }
    }

    void Update()
    {
        if (GameManager.gameOver)
        {
            StopAllCoroutines();
        }
    } 

    IEnumerator RepeatlySpawnVehicle(float xPos) // Coroutine is used since InvokeRepeating doesn't support calling with parameters
    {
        while (!GameManager.gameOver)
        {
            SpawnVehicleAtPos(xPos);
            yield return new WaitForSeconds(GetSpawnInterval());
        }
    }

    private void SpawnVehicleAtPos(float spawnPosX)
    {
        Vehicle vehicle = GetRandomVehicle();
        Instantiate(vehicle, new Vector3(spawnPosX, spawnPosY, spawnPosZ), vehicle.transform.rotation);
    }

    private float GetSpawnInterval()
    {
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private Vehicle GetRandomVehicle()
    {
        return vehicles[Random.Range(0, vehicles.Count)];
    }

    public void DespawnAllVehicles()
    {
        GameObject[] vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        foreach (GameObject vehicle in vehicles)
        {
            Destroy(vehicle);
        }
    }
}

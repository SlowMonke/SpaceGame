using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float repeatInterval;

    private bool isSpawning; // Flag to track if an enemy is currently being spawned

    public void Start()
    {
        if (repeatInterval > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
        }
    }

    // Change the return type to GameObject
    public GameObject SpawnObject()
    {
        if (!isSpawning && prefabToSpawn != null)
        {
            isSpawning = true; // Set the flag to true to indicate that an enemy is being spawned
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            StartCoroutine(MakeSpawnAvailable());
            return spawnedObject; // Return the spawned object
        }

        return null;
    }

    private IEnumerator MakeSpawnAvailable()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the duration as needed
        isSpawning = false; // Set the flag back to false to allow spawning the next enemy
    }

    // Add this method to check if the spawn point is available for spawning
    public bool IsAvailable()
    {
        return !isSpawning;
    }
}

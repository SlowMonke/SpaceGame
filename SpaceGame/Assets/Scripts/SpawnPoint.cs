using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private float minSpawnInterval = 2.0f; // The minimum interval between spawns
    private float maxSpawnInterval = 5.0f; // The maximum interval between spawns
    private bool isAvailable = true; // Indicates whether this spawn point is available for spawning

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomly());
    }

    private IEnumerator SpawnRandomly()
    {
        while (true)
        {
            if (isAvailable)
            {
                // Calculate a random spawn interval based on the score
                float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(randomInterval);

                SpawnObject();
            }
            else
            {
                // Wait for a short time before checking again
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    public GameObject SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            // Spawn the object and mark this spawn point as unavailable
            isAvailable = false;
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // After a certain time or event, mark this spawn point as available again
            StartCoroutine(MakeAvailableAfterDelay());

            return spawnedObject;
        }
        return null;
    }

    private IEnumerator MakeAvailableAfterDelay()
    {
        // You can adjust this delay based on your game's needs
        yield return new WaitForSeconds(5.0f);

        // Mark this spawn point as available again
        isAvailable = true;
    }
    
    public bool IsAvailable()
    {
        return isAvailable;
    }
}

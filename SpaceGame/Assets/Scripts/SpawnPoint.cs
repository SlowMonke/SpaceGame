using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private float minSpawnInterval = 2.0f; // The minimum interval between spawns
    private float maxSpawnInterval = 5.0f; // The maximum interval between spawns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomly());
    }

    private IEnumerator SpawnRandomly()
    {
        while (true)
        {
            // Calculate a random spawn interval based on the score
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);

            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
}

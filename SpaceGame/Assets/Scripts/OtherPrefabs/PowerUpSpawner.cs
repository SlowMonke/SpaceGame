using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Use an array to store the prefabs
    public float minInterval = 0.5f; 
    public float maxInterval = 2.0f; 
    public float oneskorenie = 5.0f; 

    private bool isSpawning; 

    public void Start()
    {
        StartCoroutine(SpawnObject(oneskorenie)); 
    }

    
    public IEnumerator SpawnObject(float oneskorenie)
    {
        while (true) 
        {
            if (!isSpawning && prefabsToSpawn.Length > 0) // Check if the array is not empty
            {
                isSpawning = true; 
                yield return new WaitForSeconds(oneskorenie);  
                int randomIndex = Random.Range(0, prefabsToSpawn.Length); // Get a random index from the array
                if(randomIndex == 4 || GameManager.health <= 2)
                {
                    GameObject spawnedObject = Instantiate(prefabsToSpawn[randomIndex], transform.position, Quaternion.identity); // Spawn the prefab at that index
                }else
                {
                    randomIndex = Random.Range(0, prefabsToSpawn.Length); // Get a random index from the array
                    if (randomIndex == 4 || GameManager.health <= 2)
                    {
                        GameObject spawnedObject = Instantiate(prefabsToSpawn[randomIndex], transform.position, Quaternion.identity); // Spawn the prefab at that index
                    }
                    else
                    {
                        randomIndex = Random.Range(0, prefabsToSpawn.Length); // Get a random index from the array
                        GameObject spawnedObject = Instantiate(prefabsToSpawn[randomIndex], transform.position, Quaternion.identity); // Spawn the prefab at that index
                    }
                }
                yield return new WaitForSeconds(1.0f); 
                isSpawning = false; 
            }

            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval)); 
        }
    }

    
    public bool IsAvailable()
    {
        return !isSpawning;
    }
}

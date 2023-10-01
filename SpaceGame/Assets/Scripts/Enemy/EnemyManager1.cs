using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager1 : MonoBehaviour
{
    public List<SpawnPoint2> enemySpawnPoints = new List<SpawnPoint2>();
    public GameObject enemyPrefab; // The enemy prefab to spawn
    private float minSpawnInterval = 1.0f; // Lowered initial minimum interval between enemy spawns
    private float maxSpawnInterval = 3.0f; // Lowered initial maximum interval between enemy spawns
    private int totalKilledEnemies; // Variable to track total killed enemies
    private float minSpawnIntervalLimit = 0.2f; // Minimum limit for minSpawnInterval

    private void Start()
    {
        // Start the coroutine for enemy spawning.
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Calculate a random spawn interval based on the number of killed enemies.
            float intervalModifier = Mathf.Clamp01(totalKilledEnemies / 10.0f); // Adjust the division value as needed.
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval) * Mathf.Lerp(1.0f, 0.5f, intervalModifier);

            // Get a random available spawn point.
            SpawnPoint2 spawnPoint = GetRandomAvailableSpawnPoint();

            if (spawnPoint != null)
            {
                // Spawn an enemy at the selected spawn point.
                Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

                spawnPoint.SpawnObject();

                // Wait for the specified interval before spawning the next enemy.
                yield return new WaitForSeconds(randomInterval);

                // Gradually reduce the minimum spawn interval to make enemies spawn faster over time.
                if (minSpawnInterval > minSpawnIntervalLimit)
                {
                    minSpawnInterval -= 0.05f * Time.deltaTime;
                }
            }
            else
            {
                // If no available spawn point is found, wait for a short time before checking again.
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    private SpawnPoint2 GetRandomAvailableSpawnPoint()
    {
        // Filter the list of spawn points to find available ones.
        List<SpawnPoint2> availableSpawnPoints = enemySpawnPoints.FindAll(sp => sp.IsAvailable());

        if (availableSpawnPoints.Count > 0)
        {
            // Select a random available spawn point.
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            return availableSpawnPoints[randomIndex];
        }

        return null; // No available spawn points found.
    }

    // Call this method when an enemy is killed to update the total killed enemies count.
    public void EnemyKilled()
    {
        totalKilledEnemies++;
    }
}
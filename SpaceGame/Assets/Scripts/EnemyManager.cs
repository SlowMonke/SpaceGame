using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<SpawnPoint> enemySpawnPoints = new List<SpawnPoint>();
    public GameObject enemyPrefab; // The enemy prefab to spawn
    private float minSpawnInterval = 2.0f; // The minimum initial interval between enemy spawns
    private float maxSpawnInterval = 5.0f; // The maximum initial interval between enemy spawns
    private int totalKilledEnemies; // Variable to track total killed enemies

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
            SpawnPoint spawnPoint = GetRandomAvailableSpawnPoint();

            if (spawnPoint != null)
            {
                // Spawn an enemy at the selected spawn point.
                Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

                // Mark the spawn point as unavailable for a short duration.
                spawnPoint.SpawnObject();

                // Wait for the specified interval before spawning the next enemy.
                yield return new WaitForSeconds(randomInterval);
            }
            else
            {
                // If no available spawn point is found, wait for a short time before checking again.
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    private SpawnPoint GetRandomAvailableSpawnPoint()
    {
        // Filter the list of spawn points to find available ones.
        List<SpawnPoint> availableSpawnPoints = enemySpawnPoints.FindAll(sp => sp.IsAvailable());

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

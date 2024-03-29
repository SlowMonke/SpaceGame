using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<SpawnPoint> enemySpawnPoints = new List<SpawnPoint>();
    public Transform BossSpawnPoint;
    public Transform BossSpawnPoint2;
    public Transform FirePoint;
    public GameObject enemyPrefab; // The regular enemy prefab to spawn
    public GameObject specialEnemyPrefab;
    public GameObject specialEnemyPrefab2;
    public GameObject BossPrefab;
    public GameObject BossPrefab2;// The special enemy prefab to spawn
    private float minSpawnInterval = 1.0f; // Lowered idddddnitial minimum interval between enemy spawns
    private float maxSpawnInterval = 3.0f; // Lowered initial maximum interval between enemy spawns
    private int totalKilledEnemies; // Variable to track total killed enemies
    private float minSpawnIntervalLimit = 0.2f;
    private int bosscount = 1;
    private int bosscount2 = 1;
    public GameObject startEffect;
    public GameObject startEffect2;
    public GameObject startEffect22;
    public float cooldown = 60;// Minimum limit for minSpawnInterval

    private void Start()
    {
        // Start the coroutine for enemy spawning.
        StartCoroutine(SpawnEnemies());
        bosscount = 1;
        bosscount2 = 1;
        cooldown = 60;
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
                if (Score.scoreValue >= 200 && Score.scoreValue <= 300 && Random.value <= 0.15f)
                {
                    Instantiate(specialEnemyPrefab2, spawnPoint.transform.position, Quaternion.identity);
                } else
                {
                    if (Score.scoreValue >= 100 && Score.scoreValue <= 200 && Random.value <= 0.20f)
                    {
                        // Spawn a special enemy at the selected spawn point.
                        Instantiate(specialEnemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        if (Score.scoreValue <= 300) 
                        {
                            Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                        }

                    }
                }
                if (Score.scoreValue >= 400 && Score.scoreValue <= 700 && Random.value <= 0.20f)
                {
                    Instantiate(specialEnemyPrefab2, spawnPoint.transform.position, Quaternion.identity);
                }
                else
                {
                    if (Score.scoreValue >= 400 && Score.scoreValue <= 700 && Random.value <= 0.20f)
                    {
                        // Spawn a special enemy at the selected spawn point.
                        Instantiate(specialEnemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        if (Score.scoreValue >= 400 && Score.scoreValue <= 700)
                        {
                            Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                        }

                    }
                }
                if (Score.scoreValue >= 800 && Score.scoreValue <= 70000 && Random.value <= 0.20f)
                {
                    Instantiate(specialEnemyPrefab2, spawnPoint.transform.position, Quaternion.identity);
                }
                else
                {
                    if (Score.scoreValue >= 800 && Score.scoreValue <= 70000 && Random.value <= 0.25f)
                    {
                        // Spawn a special enemy at the selected spawn point.
                        Instantiate(specialEnemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        if (Score.scoreValue >= 800 && Score.scoreValue <= 70000)
                        {
                            Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                        }

                    }
                }
                if (Score.scoreValue >= 300 && bosscount == 1)
                {
                    Invoke("SpawnBoss1", 4f);
                    Invoke("BossParticle", 2f);
                    bosscount -= 1;
                    Instantiate(startEffect, transform.position, transform.rotation);
                }
                if (Score.scoreValue >= 700 && bosscount2 == 1)
                {
                    Invoke("SpawnBoss2",6f);
                    Invoke("BossParticle2", 2f);
                    bosscount2 -= 1;
                }

                // Mark the spawn point as unavailable for a short duration.
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
    void Update()
    {
        if (cooldown <= 0)
        {
            if (bosscount == 0 && Score.scoreValue >= 1100 && Score.scoreValue <= 1110 && bosscount2 == 0)
            {
                if (Random.value <= 0.5)
                {
                    bosscount += 1;
                }
                else
                {
                    bosscount2 += 1;
                }
                
                cooldown = 60;
            }
        }
        cooldown -= Time.deltaTime;
    }

    public void SpawnBoss1()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 90);
        Instantiate(BossPrefab, BossSpawnPoint.transform.position, rotation);
        Instantiate(startEffect, transform.position, transform.rotation);
    }
    public void SpawnBoss2()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(BossPrefab2, BossSpawnPoint2.position, rotation);
    }
    public void BossParticle()
    {
        Instantiate(startEffect, transform.position, transform.rotation);
    }
    public void BossParticle2()
    {
        Instantiate(startEffect2, FirePoint.position, FirePoint.rotation);
        Invoke("BossParticle22", 4f);
    }
    public void BossParticle22()
    {
        Instantiate(startEffect22, FirePoint.position, FirePoint.rotation);
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

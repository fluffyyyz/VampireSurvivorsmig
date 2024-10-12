using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject batPrefab;        // Assign the bat prefab in the inspector
    public float spawnInterval = 0.5f;  // Time between spawns
    public float spawnRadius = 5f;      // Distance from the spawner where the bats will spawn
    public int maxBats = 20;            // Maximum number of bats to be spawned
    private int currentBatCount = 0;    // Counter for how many bats are currently active

    void Start()
    {
        // Start spawning bats at regular intervals
        InvokeRepeating("SpawnBat", 0f, spawnInterval);
    }

    void SpawnBat()
    {
        // Only spawn if the current number of bats is less than the maximum allowed
        if (currentBatCount >= maxBats) return;

        // Generate a random spawn position around the spawner
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        // Spawn the bat at the calculated position
        Instantiate(batPrefab, spawnPos, Quaternion.identity);

        // Increment the current bat count
        currentBatCount++;
    }

    public void ResetBatCount()
    {
        // Call this method to reset the count (e.g., when bats die)
        currentBatCount = 0;
    }

    public void DecreaseBatCount()
    {
        // Call this method when a bat is manually destroyed to decrease the bat count
        currentBatCount--;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        SpawnPlayer();
    }

    public GameObject SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            return Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        return null;
    }
}

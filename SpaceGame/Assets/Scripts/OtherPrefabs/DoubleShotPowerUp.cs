using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPowerUp : MonoBehaviour
{
    // Reference to the BulletMovement script
    public BulletMovement bulletMovement;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingPowerUp : MonoBehaviour
{
    // Reference to the BulletMovement script
    public BulletMovement bulletMovement;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            Debug.Log("Hello World");            
            Destroy(gameObject);
            bulletMovement.piercingActivated = true;
        }
    }
}


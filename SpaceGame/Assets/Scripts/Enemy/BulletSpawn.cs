using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float ShootingDelay = 2f;

    void Start()
    {
        ShootingDelay = 2;
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            ShootingDelay -= Time.deltaTime;
            
                if (ShootingDelay <= 0)
                {
                    Shoot();
                    ShootingDelay = 2f;
                }
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

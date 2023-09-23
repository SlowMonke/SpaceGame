 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float ShootingDelay = 0.5f;


    void Start()
    {
        ShootingDelay = 0;
    }

    void Update ()
    {
        ShootingDelay -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if (ShootingDelay <= 0)
            {
                Shoot();
                ShootingDelay = 0.5f;
            }
            
        }

    }

    void Shoot () 
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

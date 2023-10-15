 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;
    public float ShootingDelay = 0.3f;
    public bool SmallCooldownActivated = false;

    void Start()
    {
        ShootingDelay = 0;
    }

    void Update ()
    {
        if (!PauseMenu.isPaused)
        {
            ShootingDelay -= Time.deltaTime;
            if (Input.GetButtonDown("Fire1"))
            {
                if (ShootingDelay <= 0)
                {
                    Shoot();
                    if (GameManager.cooldownOnDelay >= 1)
                    {
                        ShootingDelay = 0.15f;
                    }
                    else
                    {
                        ShootingDelay = 0.3f;
                    }
                }
            }
        }
        
    }

    void Shoot () 
    {
        if (GameManager.cooldownOnDoubleShot >= 1)
        {
            Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("PowerUp"))
        {
            GameManager.cooldownOnPiercing = 10;
        }

        if (hitInfo.CompareTag("PowerUp2"))
        {
            GameManager.cooldownOnDelay = 10;
        }

        if (hitInfo.CompareTag("PowerUp3"))
        {
            GameManager.cooldownOnDoubleShot = 10;
        }
    }
}

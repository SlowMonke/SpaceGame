using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbility2 : MonoBehaviour
{
    public Transform CenterPoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public Transform firePoint7;
    public Transform firePoint8;
    public Transform firePoint9;
    public Transform firePoint10;
    public Transform firePoint11;
    public Transform firePoint12;
    public Transform firePoint13;
    public Transform firePoint14;
    public Transform firePoint15;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnSpiralSword1;
    public Transform SpawnSpiralSword2;
    public GameObject InvisObj;
    public GameObject SpiralSword;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject MinionPrefab;


    public float ShootingDelay = 2f;
    public Transform rocket;
    public Transform boss;

    void Start()
    {
        ShootingDelay = 5;
        Shoot();

    }

    void Update()
    {
        if (rocket != null)
        {
            float distance = (rocket.position - boss.position).magnitude;

            if (!PauseMenu.isPaused)
            {
                ShootingDelay -= Time.deltaTime;
            }
            if (ShootingDelay <= 0)
            {
                if (distance <= 9 && Random.value <= 0.25)
                {
                    Ability4();
                }
                else
                {
                    if (Random.value <= 0.3f)
                    {
                        Ability2();
                    }
                    else
                    {
                        if (Random.value <= 0.3f)
                        {
                            Ability3();
                        }
                        else
                        {
                            if (Random.value <= 0.5f)
                            {
                                Ability1();
                            }
                        }
                    }
                }
            }
        }
    }


    void Ability1()
    {
        Shoot();
        Invoke("Shoot2", 1f);
        ShootingDelay = 4f;
    }

    void Ability2()
    {
        FallingAbilityPart1();
        Invoke("FallingAbilityPart2", 2f);
        ShootingDelay = 5f;
    }

    void Ability3()
    {

        ShootingDelay = 10f;
    }

    void Ability4()
    {

        ShootingDelay = 7f;

    }

    void Shoot2()
    {
    }

    void Shoot()
    {
        Instantiate(InvisObj, CenterPoint.position, CenterPoint.rotation);
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
        Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
        Instantiate(bulletPrefab, firePoint6.position, firePoint6.rotation);
        Instantiate(bulletPrefab, firePoint7.position, firePoint7.rotation);
        Instantiate(bulletPrefab, firePoint8.position, firePoint8.rotation);
        Instantiate(bulletPrefab, firePoint9.position, firePoint9.rotation);
        Instantiate(bulletPrefab, firePoint10.position, firePoint10.rotation);
        Instantiate(bulletPrefab, firePoint11.position, firePoint11.rotation);
        Instantiate(bulletPrefab, firePoint12.position, firePoint12.rotation);

    }
    void FallingAbilityPart1()
    {
        Instantiate(bulletPrefab2, firePoint7.position, firePoint7.rotation);
        Instantiate(bulletPrefab2, firePoint8.position, firePoint8.rotation);
        Instantiate(bulletPrefab2, firePoint9.position, firePoint9.rotation);
        Instantiate(bulletPrefab2, firePoint10.position, firePoint10.rotation);
        Instantiate(bulletPrefab2, firePoint11.position, firePoint11.rotation);
        Instantiate(bulletPrefab, CenterPoint.position, CenterPoint.rotation);
    }
    void FallingAbilityPart2()
    {
        Instantiate(bulletPrefab2, firePoint12.position, firePoint12.rotation);
        Instantiate(bulletPrefab2, firePoint13.position, firePoint13.rotation);
        Instantiate(bulletPrefab2, firePoint14.position, firePoint14.rotation);
        Instantiate(bulletPrefab2, firePoint15.position, firePoint15.rotation);
    }
}

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
    public Transform firePoint16;
    public Transform firePoint17;
    public Transform firePoint18;
    public Transform firePoint19;
    public Transform firePoint199;
    public Transform firePoint20;
    public Transform firePoint21;
    public Transform firePoint22;
    public Transform firePoint23;
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
    public float Delay = 2f;
    public Transform rocket;
    public Transform boss;

    void Start()
    {
        ShootingDelay = 5f;
        Delay = 2f;
    }

    void Update()
    {
        if (rocket != null)
        {
            float distance = (rocket.position - boss.position).magnitude;

            if (!PauseMenu.isPaused)
            {
                ShootingDelay -= Time.deltaTime;
                Delay -= Time.deltaTime;
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
                            if (Random.value <= 0.5f)
                            {
                                
                            }
                        }
                    }
            }
           
        }
        if (Delay <= 0)
        {
            Debug.Log("ahoj");
            if (GameManager.healthboss == 75 || GameManager.healthboss == 50 || GameManager.healthboss == 25)
            {
                Ability1();
                Delay = 5f;
                GameManager.healthboss -= 1;
            }
        }
    }


    void Ability1()
    {
        Shoot();
        Invoke("Shoot2", 1f);
        ShootingDelay = 12f;
    }

    void Ability2()
    {
        FallingAbilityPart1();
        ShootingDelay = 5f;
    }

    void Ability3()
    {

        ShootingDelay = 10f;
    }

    void Ability4()
    {
        ShootingDelay = 12f;
        Instantiate(bulletPrefab2, firePoint13.position, firePoint13.rotation);
        Instantiate(bulletPrefab2, firePoint14.position, firePoint14.rotation);
        Instantiate(bulletPrefab2, firePoint15.position, firePoint15.rotation);
        Instantiate(bulletPrefab2, firePoint16.position, firePoint16.rotation);
        Invoke("Shoot2", 6f);

    }

    void Shoot2()
    {
        Instantiate(bulletPrefab2, firePoint17.position, firePoint17.rotation);
        Instantiate(bulletPrefab2, firePoint18.position, firePoint18.rotation);
        Instantiate(bulletPrefab2, firePoint19.position, firePoint19.rotation);
        Instantiate(bulletPrefab2, firePoint199.position, firePoint199.rotation);
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
        Instantiate(SpiralSword, firePoint20.position, firePoint20.rotation);
        Instantiate(SpiralSword, firePoint21.position, firePoint21.rotation);
        Instantiate(SpiralSword, firePoint22.position, firePoint22.rotation);
        Instantiate(SpiralSword, firePoint23.position, firePoint23.rotation);
        Invoke("FallingAbilityPart2", 5f);
    }
    void FallingAbilityPart2()
    {
        Destroy(SpiralSword);
    }
}

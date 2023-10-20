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
    public Transform firePoint24;
    public Transform firePoint25;
    public Transform firePoint26;
    public Transform firePoint27;
    public Transform firePoint28;
    public Transform firePoint29;
    public Transform firePoint30;
    public Transform firePoint31;
    public Transform MiniSpawn1;
    public Transform MiniSpawn2;
    public Transform MiniSpawn3;
    public Transform MiniSpawn4;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnSpiralSword1;
    public Transform SpawnSpiralSword2;
    public Transform fire2Point1;
    public Transform fire2Point2;
    public Transform fire2Point3;
    public Transform fire2Point4;
    public Transform fire2Point5;
    public Transform fire2Point6;
    public Transform fire2Point7;
    public Transform fire2Point8;
    public Transform fire2Point9;
    public Transform fire2Point10;
    public Transform fire2Point11;
    public Transform fire2Point12;
    public Transform fire2Point13;
    public Transform fire2Point14;
    public Transform fire2Point15;
    public Transform fire2Point16;
    public GameObject InvisObj;
    public GameObject Laser1;
    public GameObject Laser2;
    public GameObject Laser3;
    public GameObject Laser4;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject MinionPrefab;
    public GameObject MiniMaco;


    public float ShootingDelay = 2f;
    public float Delay = 2f;
    public float laserIndicator = 0f;
    public Transform rocket;
    public Transform boss;
    public float Ability1cooldown = 2f;
    public float Ability2cooldown = 2f;
    public float Ability3cooldown = 2f;
    public float Ability4cooldown = 2f;
    public float Ability5cooldown = 2f;
    public float Ability6cooldown = 2f;
    public float Ability7cooldown = 2f;

    void Start()
    {
        ShootingDelay = 3f;
        Delay = 2f;
        laserIndicator = 0f;
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
                Ability7cooldown -= Time.deltaTime;
                Ability6cooldown -= Time.deltaTime;
                Ability5cooldown -= Time.deltaTime;
                Ability4cooldown -= Time.deltaTime;
                Ability3cooldown -= Time.deltaTime;
                Ability2cooldown -= Time.deltaTime;
                Ability1cooldown -= Time.deltaTime;
            }
            if (ShootingDelay <= 0)
            {
                    if (Random.value <= 0.25 && Ability4cooldown <= 0)
                    {
                        Ability4();
                    }
                    else
                    {
                        if (Random.value <= 0.25 && Ability2cooldown <= 0)
                        {
                            Ability2();
                        }
                        else
                        {
                            if (Random.value <= 0.25 && Ability3cooldown <= 0)
                            {
                               Ability3();
                            } else
                            {
                            if (Random.value <= 0.25 && Ability5cooldown <= 0)
                            {
                                Ability5();
                            }
                            else
                            {
                                if(Random.value <= 0.25 && Ability6cooldown <= 0)
                                {
                                    Ability6();
                                }else
                                {
                                    if (Random.value <= 0.25 && Ability7cooldown <= 0)
                                    {
                                        Ability7();
                                    }
                                }
                            }
                            }
                        }
                    }
            }
           
        }
        if (Delay <= 0)
        {
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
        Ability1cooldown = 15f;
    }

    void Ability2()
    {
        FallingAbilityPart1();
        ShootingDelay = 8f;
        Ability2cooldown = 15f;
    }

    void Ability3()
    {
        if (Random.value <= 0.5)
        {
            Instantiate(MiniMaco, MiniSpawn1.position, MiniSpawn1.rotation);
            Instantiate(MiniMaco, MiniSpawn2.position, MiniSpawn2.rotation);
        }
        else
        {
            Instantiate(MiniMaco, MiniSpawn3.position, MiniSpawn3.rotation);
            Instantiate(MiniMaco, MiniSpawn4.position, MiniSpawn4.rotation);
        }
        ShootingDelay = 7f;
        Ability3cooldown = 25f;
    }
    

    void Ability4()
    {
        ShootingDelay = 8f;
        Ability4cooldown = 15f;
        Instantiate(bulletPrefab2, firePoint13.position, firePoint13.rotation);
        Instantiate(bulletPrefab2, firePoint14.position, firePoint14.rotation);
        Instantiate(bulletPrefab2, firePoint15.position, firePoint15.rotation);
        Instantiate(bulletPrefab2, firePoint16.position, firePoint16.rotation);
        Invoke("Shoot2", 4f);

    }

    void Ability5()
    {
        ShootingDelay = 8f;
        Ability5cooldown = 15f;
        Instantiate(bulletPrefab2, fire2Point1.position, fire2Point1.rotation);
        Instantiate(bulletPrefab2, fire2Point2.position, fire2Point2.rotation);
        Instantiate(bulletPrefab2, fire2Point3.position, fire2Point3.rotation);
        Instantiate(bulletPrefab2, fire2Point4.position, fire2Point4.rotation);
        Invoke("Shoot3", 4f);
    }
    void Ability6()
    {
        ShootingDelay = 8f;
        Ability6cooldown = 15f;
        Instantiate(bulletPrefab2, fire2Point9.position, fire2Point9.rotation);
        Instantiate(bulletPrefab2, fire2Point10.position, fire2Point10.rotation);
        Instantiate(bulletPrefab2, fire2Point11.position, fire2Point11.rotation);
        Instantiate(bulletPrefab2, fire2Point12.position, fire2Point12.rotation);
        Invoke("Shoot4", 4f);
    }

    void Ability7()
    {
        ShootingDelay = 8f;
        Ability7cooldown = 15f;
        Instantiate(bulletPrefab2, firePoint24.position, firePoint24.rotation);
        Instantiate(bulletPrefab2, firePoint25.position, firePoint25.rotation);
        Instantiate(bulletPrefab2, firePoint26.position, firePoint26.rotation);
        Instantiate(bulletPrefab2, firePoint27.position, firePoint27.rotation);
        Invoke("Shoot5", 4f);
    }
    void Shoot3()
    {
        Instantiate(bulletPrefab2, fire2Point5.position, fire2Point5.rotation);
        Instantiate(bulletPrefab2, fire2Point6.position, fire2Point6.rotation);
        Instantiate(bulletPrefab2, fire2Point7.position, fire2Point7.rotation);
        Instantiate(bulletPrefab2, fire2Point8.position, fire2Point8.rotation);
    }

    void Shoot4()
    {
        Instantiate(bulletPrefab2, fire2Point13.position, fire2Point13.rotation);
        Instantiate(bulletPrefab2, fire2Point14.position, fire2Point14.rotation);
        Instantiate(bulletPrefab2, fire2Point15.position, fire2Point15.rotation);
        Instantiate(bulletPrefab2, fire2Point16.position, fire2Point16.rotation);
    }

    void Shoot5()
    {
        Instantiate(bulletPrefab2, firePoint28.position, firePoint28.rotation);
        Instantiate(bulletPrefab2, firePoint29.position, firePoint29.rotation);
        Instantiate(bulletPrefab2, firePoint30.position, firePoint30.rotation);
        Instantiate(bulletPrefab2, firePoint31.position, firePoint31.rotation);
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
        if (laserIndicator == 0)
        {
            Instantiate(Laser1, firePoint20.position, firePoint20.rotation);
            Instantiate(Laser2, firePoint21.position, firePoint21.rotation);
            Instantiate(Laser3, firePoint22.position, firePoint22.rotation);
            Instantiate(Laser4, firePoint23.position, firePoint23.rotation);
            laserIndicator += 1f;
        }
        else
        {
            Instantiate(Laser1, firePoint20.position, firePoint20.rotation);
            Instantiate(Laser2, firePoint21.position, firePoint21.rotation);
            Instantiate(Laser3, firePoint22.position, firePoint22.rotation);
            Instantiate(Laser4, firePoint23.position, firePoint23.rotation);
            laserIndicator -= 1f;
        }

       
    }
}

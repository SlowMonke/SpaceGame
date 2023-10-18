using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    public float cooldown = 2f;
    public float cooldown2 = 2f;
    public Transform FirePoint;
    public GameObject bulletPrefab;
     

    void Start()
    {
        cooldown = 3f;
        cooldown2 = 6f;
    }

    
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            Shoot();
            cooldown = 0.5f;
        }
        if(cooldown2 <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}

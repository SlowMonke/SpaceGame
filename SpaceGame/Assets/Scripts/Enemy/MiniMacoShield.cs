using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMacoShield : MonoBehaviour
{
    public Transform ShieldPoint1;
    public GameObject Shield;
    public float cooldown = 3f;

    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            Shoot();
            cooldown = 3f;
        }
    }
    void Start()
    {
        cooldown = 3f;
    }

    void Shoot()
    {
        Instantiate(Shield, ShieldPoint1.position, ShieldPoint1.rotation);
    }
}

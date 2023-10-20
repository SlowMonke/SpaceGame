using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOrbHealth : MonoBehaviour
{
    public int health = 1;
    public Rigidbody rb;
    public void TakeDamage(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}

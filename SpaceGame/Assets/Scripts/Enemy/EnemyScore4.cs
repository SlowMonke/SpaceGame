using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore4 : MonoBehaviour
{
    public int health = 1;
    public Rigidbody rb;
    public GameObject deathEffect;
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
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}


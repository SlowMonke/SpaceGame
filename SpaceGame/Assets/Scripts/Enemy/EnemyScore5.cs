using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore5 : MonoBehaviour
{
    public int health = 1;
    public Rigidbody rb;
    public GameObject deathEffect;
    public void TakeDamage(int damage)
    {
        GameManager.healthboss -= damage;


        if (GameManager.healthboss <= 0)
        {
            Die();
            Score.scoreValue += 100;
        }
    }

    // Update is called once per frame
    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void Update()
    {
        health = GameManager.healthboss;
    }
}

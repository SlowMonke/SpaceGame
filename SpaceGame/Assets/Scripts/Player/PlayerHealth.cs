using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public Rigidbody rb;
    public GameObject deathEffect;
    public int numOfHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float cooldown = 0.0000000000000000000000000000001f;

    public Image[] hearts;


    public void TakeDamage(int damage)
    {
        GameManager.health -= damage;
        if (GameManager.health <= 0)
        {
            Invoke("Die", 0.005f);
        }
    }


    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Update()
    {
        health = GameManager.health;
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}

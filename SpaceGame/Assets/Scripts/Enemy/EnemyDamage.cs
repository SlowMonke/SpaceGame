using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();

            if (Player != null)
            {
                Player.TakeDamage(damage);

            }
            Destroy(gameObject);
        }
    }
}

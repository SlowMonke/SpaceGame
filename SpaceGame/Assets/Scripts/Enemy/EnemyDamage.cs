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
        PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();
        if (Player != null)
        {
            Player.TakeDamage(1);

        }
        Destroy(gameObject);
    }
}

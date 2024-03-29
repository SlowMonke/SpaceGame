using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageBoss2 : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public int damage = 1;
    public float cooldownontouch = 2f;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") && cooldownontouch <= 0)
        {
            PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();

            if (Player != null)
            {
                Player.TakeDamage(damage);

            }
            cooldownontouch = 2f;
        }
    }
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            cooldownontouch -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage4 : MonoBehaviour
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
                GameManager.particleHealth4 += 1;
                Destroy(gameObject);

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

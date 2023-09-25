using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 10f;
    Rigidbody2D rb2d;
    float startY;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startY = transform.position.y;
    }

    private void Update()
    {
        if (Score.scoreValue == 20)
        {
            float currentY = transform.position.y;
            if (currentY - startY < maxDistance)
            {
                rb2d.velocity = transform.up * speed;
            }
            else
            {
                rb2d.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming the "piercing" variable is in another script attached to the same GameObject
            BulletMovement bulletMovement = GetComponent<BulletMovement>();
            if (bulletMovement != null)
            {
                bulletMovement.piercing = true;
            }
            
            Destroy(gameObject);
        }
    }
}

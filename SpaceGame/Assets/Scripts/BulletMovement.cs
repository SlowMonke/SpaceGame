using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    private int hitCount; // variable to keep track of how many enemies the bullet has hit

    void Start()
    {
        rb.velocity = transform.up * speed;
        hitCount = 0; // initialize hit count to zero
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the collider type is PolygonCollider2D
        if (hitInfo.GetType() == typeof(PolygonCollider2D))
        {
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Score.scoreValue += 5; // multiply score value by two
                hitCount++; // increment hit count by one
                if (hitCount == 2) // check if hit count is equal to two
                {
                    Destroy(gameObject); // destroy the bullet object
                }
            }
            
        }
    }

    // Update is called once per frame

}

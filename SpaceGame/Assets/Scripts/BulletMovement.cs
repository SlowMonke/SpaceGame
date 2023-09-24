using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    // Add a variable to count the number of enemies killed by this bullet
    private int killCount = 0;
    void Start()
    {
        rb.velocity = transform.up * speed;
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
                // Increment the kill count by one
                killCount++;
                // If the kill count is two, double the score value
                if (killCount == 2)
                {
                    Score.scoreValue += 10;
                }
                else
                {
                    Score.scoreValue += 5;
                }
            }
            // Do not destroy the bullet until it hits two enemies or leaves the screen
            if (killCount == 2 || transform.position.y > Camera.main.orthographicSize)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame

}

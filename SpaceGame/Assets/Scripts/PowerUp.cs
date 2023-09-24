using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 5f; // the speed of the power up
    public float maxDistance = 10f; // the maximum distance to move up
    Rigidbody2D rb2d;
    float startY; // the initial y position of the power up
    public int value = 10; // the value of the power up
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startY = transform.position.y; // store the initial y position
    }

    // Update is called once per frame
    private void Update()
    {
        if (Score.scoreValue == 20)
        {
            float currentY = transform.position.y; // get the current y position
            if (currentY - startY < maxDistance) // check if the distance is less than the maximum
            {
                rb2d.velocity = transform.up * speed; // move up with the speed
            }
            else
            {
                rb2d.velocity = Vector2.zero; // stop moving
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // check if the other collider is the player
        {
            Score.scoreValue += value; // increase the score by the value of the power up
            
           
            Destroy(gameObject); // destroy the power up game object
        }
    }
}

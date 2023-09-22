using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChasing : MonoBehaviour
{
    public float pursuitSpeed;
    private float currentSpeed;
    public bool followPlayer;
    Coroutine moveCoroutine;
    Rigidbody2D rb2d;
    Transform targetTransform = null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            // Store the player's transform and start chasing
            targetTransform = collision.gameObject.transform;

            // Set the currentSpeed to pursuitSpeed
            currentSpeed = pursuitSpeed;

            StartChasing();
        }
    }

    void StartChasing()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveTowardsPlayer());
    }

    IEnumerator MoveTowardsPlayer()
    {
        while (targetTransform != null)
        {
            // Calculate direction towards the player
            Vector2 direction = targetTransform.position - transform.position;
            direction.Normalize();

            // Move towards the player
            rb2d.velocity = direction * currentSpeed;

            yield return null;
        }
    }

    // Initialize the Rigidbody2D component
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}


using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;  // Reference to the player's ship
    public float moveSpeed = 5f;  // Adjust this value for the enemy's movement speed
    public float avoidanceRadius = 2f;  // Radius within which enemies avoid each other

    private void Start()
    {
        // Find the player's ship GameObject in the scene by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;

            // Check for nearby enemies to avoid
            Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, avoidanceRadius);

            Vector2 avoidanceDirection = Vector2.zero;

            foreach (Collider2D enemy in nearbyEnemies)
            {
                if (enemy != null && enemy.gameObject != this.gameObject)
                {
                    avoidanceDirection += ((Vector2)transform.position - (Vector2)enemy.transform.position).normalized;
                }
            }

            // Combine the direction towards the player and the avoidance direction
            Vector2 combinedDirection = direction + avoidanceDirection.normalized;

            // Move the enemy towards the combined direction
            transform.Translate(combinedDirection * moveSpeed * Time.deltaTime);
        }
    }
}

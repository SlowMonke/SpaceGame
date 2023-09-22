using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;  // Reference to the player's ship
    public float moveSpeed = 5f;  // Adjust this value for the enemy's movement speed
    public float raycastDistance = 2f;  // Distance to check for obstacles

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
            Vector3 direction = (player.position - transform.position).normalized;

            // Cast a ray forward to check for obstacles
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // If an obstacle is detected, change direction randomly
                Vector3 randomDirection = Random.insideUnitSphere;
                randomDirection.y = 0;  // Ensure the direction is in the horizontal plane
                direction += randomDirection.normalized;
            }

            // Move the enemy towards the new direction
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}

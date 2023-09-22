using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;  // Reference to the player's ship
    public float moveSpeed = 5f;  // Adjust this value for the enemy's movement speed

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

            // Move the enemy towards the player
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}

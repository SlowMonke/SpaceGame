using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply on contact

    private void OnParticleCollision(GameObject other)
    {
        // Check if the collided object is the player character
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth script from the player object (you'll need to create this script)
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Apply damage to the player
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}

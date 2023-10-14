using UnityEngine;

public class RotationOfSpiralSword : MonoBehaviour
{
    public float torqueAmount = 1.0f; // Adjust the torque strength as needed for slow rotation
    private Rigidbody2D rb;
    public float cooldown = 6f;

    private void Start()
    {
        cooldown = 6f;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Apply a small amount of torque to make it rotate slowly
        rb.AddTorque(torqueAmount);
        if (!PauseMenu.isPaused)
        {
            cooldown -= Time.deltaTime;
        }
        if(cooldown <= 0)
        {
            Destroy(gameObject);
        }
    }
}


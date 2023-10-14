using UnityEngine;

public class AxeRotation : MonoBehaviour
{
    public float torqueAmount = 1.0f; // Adjust the torque strength as needed for slow rotation
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Apply a small amount of torque to make it rotate slowly
        rb.AddTorque(torqueAmount);
    }
}

using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f; // Adjust the rotation speed as needed

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the horizontal and vertical input axes (-1 to 1) for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the move direction based on the input axes
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        // Rotate the rocket smoothly in the shortest direction
        if (moveDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, newAngle);
        }

        // Move the rocket based on the move direction and speed using physics
        rb.velocity = moveDirection * moveSpeed;
    }
}

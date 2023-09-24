using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRotation : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 250f; 

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        PreventPlayerGoingOffScren();
    }

    private void FixedUpdate()
    {

        if (moveDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, newAngle);
        }


        rb.velocity = moveDirection * moveSpeed;
    }

    private void PreventPlayerGoingOffScren()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < 0 && rb.velocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if ((screenPosition.y < 0 && rb.velocity.y < 0) ||
           (screenPosition.y > _camera.pixelHeight && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}

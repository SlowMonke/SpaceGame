using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 250f;

    private Vector2 moveDirection;
    private Rigidbody2D _rigidbody;
    private Camera _camera;

    [SerializeField]
    private float _screenBorder;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //_rigidbody.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
          moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

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
        _rigidbody.velocity = moveDirection * moveSpeed;
    }

    private void PreventPlayerGoingOffScren()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < _screenBorder && moveDirection.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _screenBorder && moveDirection.x > 0))
        {
            moveDirection = new Vector2(0, moveDirection.y);
        }

        if ((screenPosition.y < _screenBorder && moveDirection.y < 0) ||
           (screenPosition.y > _camera.pixelHeight - _screenBorder && moveDirection.y > 0))
        {
            moveDirection = new Vector2(moveDirection.x, 0);
        }
    }
}

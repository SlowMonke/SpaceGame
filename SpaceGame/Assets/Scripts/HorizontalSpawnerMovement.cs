using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpawnerMovement : MonoBehaviour
{
    public float horizontalSpeed = 1.0f; // Adjust the speed of horizontal movement
    public float horizontalRange = 2.0f; // Adjust the range of horizontal movement

    private Vector3 initialPosition;
    private float startX;

    private void Start()
    {
        initialPosition = transform.position;
        startX = initialPosition.x;
    }

    private void Update()
    {
        // Calculate the new X position based on sine wave movement
        float newX = startX + Mathf.Sin(Time.time * horizontalSpeed) * horizontalRange;

        // Apply the new position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}

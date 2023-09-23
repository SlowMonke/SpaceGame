using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpawnerMovement : MonoBehaviour
{
    public float verticalSpeed = 1.0f; // Adjust the speed of vertical movement
    public float verticalRange = 2.0f; // Adjust the range of vertical movement

    private Vector3 initialPosition;
    private float startY;

    private void Start()
    {
        initialPosition = transform.position;
        startY = initialPosition.y;
    }

    private void Update()
    {
        // Calculate the new Y position based on sine wave movement
        float newY = startY + Mathf.Sin(Time.time * verticalSpeed) * verticalRange;

        // Apply the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

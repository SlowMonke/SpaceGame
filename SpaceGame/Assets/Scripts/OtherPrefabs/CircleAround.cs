using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAround : MonoBehaviour
{
    public float rotationSpeed = 180.0f; // Adjust the rotation speed as needed
    private Transform target;

    private void Start()
    {
        // Find the target (the boss or the object around which the bullets should rotate)
        target = GameObject.Find("Maco(Clone)").transform; // Replace "Boss" with the actual name of your boss object
    }

    private void Update()
    {
        if (target != null)
        {
            // Rotate the bullet around the target
            transform.RotateAround(target.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // If the target is destroyed, destroy the bullet
            Destroy(gameObject);
        }
    }
}

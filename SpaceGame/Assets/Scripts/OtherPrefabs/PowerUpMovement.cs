using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust this value to control the speed of the movement
    public float distanceToMove = 1.0f; // Distance to move up (set in the Unity Inspector)
    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveUpAndStop());
    }

    IEnumerator MoveUpAndStop()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * distanceToMove; // Move the specified distance up

        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                isMoving = false; // Stop the movement
            }

            yield return null;
        }
    }

}

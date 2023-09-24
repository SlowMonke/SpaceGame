using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue;

    private float minSpawnInterval = 5.0f; // Initial minimum spawn interval
    private float maxSpawnInterval = 10.0f; // Initial maximum spawn interval

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = scoreValue.ToString();
    }

    public void EnemyDestroyed()
    {
        // Increase the score when an enemy is destroyed.
        scoreValue++;

        // Adjust the spawn intervals based on the score.
        float t = Mathf.Clamp01(scoreValue / 100.0f); // Adjust the division value as needed.
        minSpawnInterval = Mathf.Lerp(2.0f, 0.5f, t); // Decrease the minimum interval.
        maxSpawnInterval = Mathf.Lerp(5.0f, 2.0f, t); // Decrease the maximum interval.

        // Optionally, you can update the spawn intervals for existing spawn points here.
    }
}


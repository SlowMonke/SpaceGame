using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver, restartButton, heart1, heart2, heart3; // Use 'GameObject' with a capital 'O' instead of 'gameObject'
    public static int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.SetActive(true); // Use 'SetActive' directly on the GameObject
        heart2.SetActive(true);
        heart3.SetActive(true);
        gameOver.SetActive(false); // Use 'SetActive' directly on the GameObject
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            default:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                gameOver.SetActive(true);
                restartButton.SetActive(true);
                Time.timeScale = 0; // Use 'Time.timeScale' with a lowercase 's'
                break;
        }
    }
}

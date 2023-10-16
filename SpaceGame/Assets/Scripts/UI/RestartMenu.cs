using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public PlayerHealth script;
    public GameObject restartMenu;
    public GameObject pauseMenu;

    void Start()
    {
        restartMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (script.health <= 0)
        {
            restartMenu.SetActive(true);
            Invoke("Cooldown", 0.5f);
        }

        if(restartMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
        }
    }


    public void Cooldown()
    {
        Time.timeScale = 0f;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level0");
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
        Score.scoreValue = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

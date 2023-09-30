using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public PlayerHealth script;
    public GameObject restartMenu;

    void Start()
    {
        restartMenu.SetActive(false);
    }

    void Update()
    {
        if (script.health <= 0)
        {
            restartMenu.SetActive(true);
        }
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

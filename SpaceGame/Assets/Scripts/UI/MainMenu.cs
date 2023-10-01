using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void PlayGame()
    {
        levelLoader.PlayGame();
        Score.scoreValue = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
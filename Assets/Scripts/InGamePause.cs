using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePause : MonoBehaviour
{
    public int MenuScreens;
    public GameObject PauseScreen, PauseButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        SceneManager.LoadScene("MenuScreens");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
    }
}

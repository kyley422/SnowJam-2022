using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class InGamePause : MonoBehaviour
{

    public Button resumeButton;
    public Button quiteButton;
    public Button pauseButton;
    public VisualElement pauseMenu;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        resumeButton = root.Q<Button>("resumeButton");
        quiteButton = root.Q<Button>("QuiteButton");
        pauseButton = root.Q<Button>("PauseButton");
        pauseMenu = root.Q<VisualElement>("PauseMenu");

        resumeButton.clicked += ResumeButtonPressed;
        quiteButton.clicked += QuitButtonPressed;
        pauseButton.clicked += PauseButtonPressed;

    }
   

    public void QuitButtonPressed()
    {
        SceneManager.LoadScene("UITest");
    }

    public void PauseButtonPressed()
    {
        Time.timeScale = 0f;
        pauseMenu.style.display = DisplayStyle.Flex;

    }

    public void ResumeButtonPressed()
    {
        Time.timeScale = 1f;
        pauseMenu.style.display = DisplayStyle.None;
    }
}

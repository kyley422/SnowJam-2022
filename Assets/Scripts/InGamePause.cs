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
        pauseMenu.style.display = DisplayStyle.Flex;
        Time.timeScale = 0;
    }

    public void ResumeButtonPressed()
    {
        pauseMenu.style.display = DisplayStyle.None;
        Time.timeScale = 1;
    }
}

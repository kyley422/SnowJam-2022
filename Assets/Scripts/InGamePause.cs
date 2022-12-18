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
    public Label pauseMenu;

    public AudioSource sound; 

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        resumeButton = root.Q<Button>("ResumeButton");
        quiteButton = root.Q<Button>("QuiteButton");
        pauseButton = root.Q<Button>("PauseButton");
        pauseMenu = root.Q<Label>("PauseMenu");

        resumeButton.clicked += ResumeButtonPressed;
        quiteButton.clicked += QuitButtonPressed;
        pauseButton.clicked += PauseButtonPressed;

    }

    public void QuitButtonPressed()
    {
        sound.Play();
        SceneManager.LoadScene("UI Test");
    }

    public void PauseButtonPressed()
    {
        sound.Play(); 
        pauseMenu.style.display = DisplayStyle.Flex;
        pauseButton.style.display = DisplayStyle.None;
        Time.timeScale = 0;
    }

    public void ResumeButtonPressed()
    {
        sound.Play(); 
        pauseMenu.style.display = DisplayStyle.None;
        pauseButton.style.display = DisplayStyle.Flex;
        Time.timeScale = 1;
    }
}

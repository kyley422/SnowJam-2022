using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;
    public Label creditsText;
   


    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        creditsButton = root.Q<Button>("CreditsButton");
        creditsText = root.Q<Label>("CreditsText");

        startButton.clicked += StartButtonPressed;
        creditsButton.clicked += CreditsButtonPresses;

    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("game");
    }

    void CreditsButtonPresses()
    {
        creditsText.text = "Team 07";
        creditsText.style.display = DisplayStyle.Flex;
    }
}

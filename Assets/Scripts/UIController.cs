using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;
    public Button backButton;
    public Label creditsText;
   
   public AudioSource sound; 

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        creditsButton = root.Q<Button>("CreditsButton");
        creditsText = root.Q<Label>("CreditsText");
        backButton = root.Q<Button>("BackButton");

        startButton.clicked += StartButtonPressed;
        creditsButton.clicked += CreditsButtonPresses;
        backButton.clicked += BackButtonPressed;

    }

    void StartButtonPressed()
    {
        sound.Play(); 
        SceneManager.LoadScene("spring");
    }

    void CreditsButtonPresses()
    {
        sound.Play(); 
        creditsText.text = "Joanna Liu - 2D Art, Writtin \n\n\n" +
                            "Catherine Sun -Programming, Audio \n\n\n" +
                            "Laura Ness - Level Design, Programming \n\n\n" +
                            "Clea Hannahs - Programming, UI / UX \n\n\n" +
                            "Kyle Machnicki -Programming, Writting \n\n\n" +
                            "My-Thuan Ha-Hoang - Level Design, Writting \n\n\n" +
                            "Kyle Yang - Programming \n\n\n" +
                            "Julia Lee -UI / UX, 2D Art";

        creditsText.style.display = DisplayStyle.Flex;
    }

    void BackButtonPressed()
    {
        sound.Play(); 
        creditsText.style.display = DisplayStyle.None;
    }
}

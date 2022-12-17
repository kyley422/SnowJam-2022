using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Button b;
    [SerializeField] string next_scene = "";

    public void Start()
    {
        if (b != null) {
            b.onClick.AddListener(NextScene);
        }
    }

    void NextScene() {
        Debug.Log("NextScene: " + next_scene);
        SceneManager.LoadScene(next_scene);
    }
}

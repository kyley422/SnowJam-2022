using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject boss;
    // Update is called once per frame
    void Start() {
        boss.SetActive(false);
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && boss != null) {
            boss.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public GameObject MainMenu, GameOver;

    public int maxHealth = 4;
    public int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < currentHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log("Player died");
            Destroy(gameObject);
            SceneManager.LoadScene("UI Test");
            MainMenu.SetActive(false);
            GameOver.SetActive(true);

        }
    }

    
}

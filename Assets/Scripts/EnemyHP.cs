using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyHP : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deathEffect;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log("Enemy died");

            // Disable enemy
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;


            StartCoroutine(DeathDelay());

        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, .3f);
        Destroy(gameObject);
    }
}


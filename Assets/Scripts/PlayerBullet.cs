using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject hitEffect;

    [SerializeField] private float duration = 3f;

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .3f);
        Destroy(gameObject);

        /* Check if other is an enemy, and if so, make it take damage. */
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(100);
        }
    }
}

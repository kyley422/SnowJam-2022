using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);

        /* Check if other is an enemy, and if so, make it take damage. */
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(100);
        }
    }
}

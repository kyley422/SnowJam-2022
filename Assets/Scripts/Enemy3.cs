using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float attackTimer = 2f;
    public GameObject bulletPrefab;
    private Vector2 playerPosition;
    private float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackTimer)
        {
            Shoot();
            /* Reset timer */
            timer = timer - attackTimer;
        }
    }

    /* Turret will fire a 3-round burst at enemy position */
    private void Shoot()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        float angle = Mathf.Atan2(playerPosition.y, playerPosition.x) * Mathf.Rad2Deg - 90f;
        Quaternion radialPosition = Quaternion.Euler(0, 0, angle);

        // GameObject enemy3_bullet = Instantiate(bulletPrefab, transform.position, radialPosition);
        // Rigidbody2D rb = enemy3_bullet.GetComponent<Rigidbody2D>();
        // rb.AddForce(playerPosition * bulletForce, ForceMode2D.Impulse);

        GameObject enemy3_bullet = Instantiate(bulletPrefab, transform.position, radialPosition);
    }
}

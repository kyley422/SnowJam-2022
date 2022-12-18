using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy4 : MonoBehaviour
{
    public float attackTimer = 2f;
    public float burstTimer = .25f;
    public float numberOfProjectiles = 12f;
    public float radius = 10f;
    public float bulletSpeed = 1f;
    public GameObject bulletPrefab;
    private Vector2 playerPosition;
    private float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        /* Begin attack */
        if (timer > attackTimer)
        {
            Burst();
            /* Reset attack timer */
            timer = timer - attackTimer;
        }
    }

    /* Enemy will fire a 3-round radial burst */
    private void Burst()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < 3; i++)
        {
            /* Begin burst */
            float angleStep = (float)(2 * Math.PI) / numberOfProjectiles;
            float angle = 0f;

            for (int j = 0; j < numberOfProjectiles; j++)
            {
                float x = transform.position.x + (float)Math.Cos(angle) * radius;
                float y = transform.position.y + (float)Math.Sin(angle) * radius;

                Vector3 bulletVector = new Vector3(x, y, 0);
                Vector3 bulletMoveDirection = (bulletVector - transform.position).normalized * bulletSpeed;

                var proj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                proj.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDirection.x, bulletMoveDirection.y);

                angle += angleStep;
            }
            yield return new WaitForSeconds(burstTimer);
        }
    }
}

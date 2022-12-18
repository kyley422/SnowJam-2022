using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy4 : MonoBehaviour
{
    enum Direction { left = -1, right = 1 };
    public float moveSpeed = 1f;
    public float patrolRange = 1f;

    public float attackTimer = 2f;
    public float burstTimer = .25f;
    public float numberOfProjectiles = 12f;
    public float radius = 10f;
    public float bulletSpeed = 1f;
    public GameObject bulletPrefab;
    private Vector2 playerPosition;
    private float timer = 0f;
    private bool movingLeft = true;
    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private Rigidbody2D rb;
    // Initial orientation of the sprite renderer
    private Vector3 initScale;
    void Start()
    {
        leftEdge = new Vector3(transform.position.x - patrolRange, transform.position.y, 0);
        rightEdge = new Vector3(transform.position.x + patrolRange, transform.position.y, 0);
        rb = GetComponent<Rigidbody2D>();
        initScale = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            // If we hit the boundary, have the enemy switch direction
            if (transform.position.x < leftEdge[0])
                movingLeft = false;
            Move(Direction.left);
        }
        else
        {
            if (transform.position.x > rightEdge[0])
                movingLeft = true;
            Move(Direction.right);
        }
        timer += Time.deltaTime;
        /* Begin attack */
        if (timer > attackTimer)
        {
            Burst();
            /* Reset attack timer */
            timer = timer - attackTimer;
        }
    }

    /* Enemy will patrol in a given area */
    void Move(Direction dir)
    {
        // Set animator boolean for movement
        //animator.SetBool("isRunning", true);

        switch (dir)
        {
            case Direction.left:
                // Keep initial orientation of sprite is moving left
                transform.localScale = new Vector3(Mathf.Abs(initScale.x), initScale.y, initScale.z);
                break;
            case Direction.right:
                // Otherwise, we flip the sprite
                transform.localScale = new Vector3(Mathf.Abs(initScale.x) * -1, initScale.y, initScale.z);
                break;
        }

        // Have enemy move in the specified direction
        rb.velocity = new Vector2(moveSpeed * (int)dir, rb.velocity.y);
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

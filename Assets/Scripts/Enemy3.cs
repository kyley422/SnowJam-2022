using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    /* Movement variables */
    enum Direction { left = -1, right = 1 };
    public float moveSpeed = 1f;
    public float patrolRange = 1f;
    private bool movingLeft = true;
    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private Rigidbody2D rb;
    /* Shooting variables */
    public float attackTimer = 2f;
    public GameObject bulletPrefab;
    private Vector2 playerPosition;
    private float timer = 0f;
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
        if (timer > attackTimer)
        {
            Shoot();
            /* Reset timer */
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    public AudioSource footsteps;

    public Animator anim;
    public float x, y;
    private bool isWalking;

    private Vector2 moveDirection;
    //private Vector2 mousePos;

    public PlayerHP hp;
    void Update()
    {
        ProcessInputs();
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);

            if (!isWalking)
            {
                isWalking = true;
                footsteps.enabled = true;
                footsteps.Play();
                anim.SetBool("IsMoving", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                footsteps.enabled = false;
                anim.SetBool("IsMoving", isWalking);
                StopMoving();
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }


    private void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        /* Collision detection for Enemy, Player must take damage. */
        if (other.gameObject.tag == "Enemy")
        {
            hp.TakeDamage(25);
        }
        /* Collision detection for Enemy bullets */
        if (other.gameObject.tag == "EnemyBullet")
        {
            hp.TakeDamage(25);
        }
    }
}
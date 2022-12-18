using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;

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

        if(x!= 0 || y!= 0)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);

            if (!isWalking)
            {
                isWalking = true;
                anim.SetBool("IsMoving", isWalking);
            }
        } else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("IsMoving", isWalking);
                StopMoving();
            }
        }
    }

    void FixedUpdate()
    {
        Move();
        //Look();
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

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    /*
    void Look()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    */

    private void OnCollisionEnter2D(Collision2D other)
    {
        /* Collision detection for Enemy, Player must take damage. */
        if (other.gameObject.tag == "Enemy")
        {
            hp.TakeDamage(100);
        }
        /* Collision detection for Enemy bullets */
        if (other.gameObject.tag == "EnemyBullet")
        {
            hp.TakeDamage(100);
        }
    }
}

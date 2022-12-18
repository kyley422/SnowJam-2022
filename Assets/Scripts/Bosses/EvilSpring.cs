using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EvilSpring : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;
    public bool isInRange = false;

    public GameObject GameOverScreen;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    /* Shooting variables */
    public float attackTimer = 2f;
    public float burstTimer = .25f;
    public float numberOfProjectiles = 12f;
    public float radius = 10f;
    public float bulletSpeed = 1f;
    public GameObject bulletPrefab;
    private Vector2 playerPosition;
    private float timer = 0f;

    public EnemyHP hp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        whatIsPlayer = LayerMask.GetMask("Player");
    }

    private void Update()
    {

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        //Debug.Log(isInChaseRange + " | " + isInAttackRange);


        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        timer += Time.deltaTime;
        if (timer > attackTimer)
        {
            Burst();
            /* Reset timer */
            timer = timer - attackTimer;
        }
    }

    private void FixedUpdate()
    {
        if (hp.currentHealth > 0)
        {
            if (isInChaseRange && !isInAttackRange)
            {
                //Debug.Log("test");
                MoveCharacter(movement);
            }
            if (isInAttackRange)
            {
                //Debug.Log("test222");
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            movement = transform.position;
            SceneManager.LoadScene("UI Test");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = true;
        }
        if (isInRange)
        {
            Debug.Log("Enemy1 killed player");
        }

    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

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

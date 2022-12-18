using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour
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

}

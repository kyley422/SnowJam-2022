using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float range;

    [SerializeField]
    float maxDistance;

    public Vector2 wayPoint;
    public Vector2 currentPos2D;

    private int unstickCounter;

    // Direction animation 
    public bool shouldRotate;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector2 dir;

    public EnemyHP hp;
    private bool isInAttackRange;

    public GameObject GameOverScreen;
    public float attackRadius;
    public LayerMask whatIsPlayer;


    void Start()
    {
        // Direction animation
        rb = GetComponent<Rigidbody2D>();


        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos2D = new Vector2(transform.position.x, transform.position.y);
        if (hp.currentHealth <= 0)
        {
            wayPoint = transform.position;
        }
        else
        {
            isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
            if (isInAttackRange)
            {
                //Debug.Log("test222");
                rb.velocity = Vector2.zero;
                GameObject.Find("Player").GetComponent<PlayerController>().isDead = true;
                Debug.Log("Enemy2 killed player" + transform.position + " | " + wayPoint);
                GameOverScreen.SetActive(true);
            }

            unstickCounter++;

            // Direction animation 

           
            dir = wayPoint;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();
            movement = dir;

            Debug.Log(currentPos2D + wayPoint);
            transform.position = Vector2.MoveTowards(currentPos2D, currentPos2D + wayPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoint) < range)
            {
                SetNewDestination();
            }

            if (unstickCounter > 300)
            {
                unstickCounter = 0;
                SetNewDestination();
            }
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}

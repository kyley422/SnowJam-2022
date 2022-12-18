using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPosition;
    public float bulletSpeed = 1.5f;
    [SerializeField] private float duration = 3f;
    private void Start()
    {
        if (GameObject.Find("Player") != null) {
            target = GameObject.Find("Player").transform;
            targetPosition = (target.position - transform.position).normalized;
        }
    }
    private void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, targetPosition, bulletSpeed * Time.deltaTime);
        //transform.Translate(targetPosition * Time.deltaTime, Space.Self);
        transform.position += targetPosition * bulletSpeed * Time.deltaTime;
        duration -= Time.deltaTime;
        if (duration <= 0) {
            Destroy(gameObject);
        }
    }
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .3f);
        Destroy(gameObject);      
    }
}

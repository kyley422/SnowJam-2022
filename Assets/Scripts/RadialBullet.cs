using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBullet : MonoBehaviour
{
    [SerializeField] private float duration = 3f;
    private void Start()
    {

    }
    private void Update()
    {
        //transform.position += targetPosition * bulletSpeed * Time.deltaTime;
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}

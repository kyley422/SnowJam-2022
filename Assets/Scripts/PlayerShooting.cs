using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    /* The empty gameObject that determines where on the Player the bullet is fired from. */
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Camera cam;
    private Vector2 mousePos;
    private bool isAttacking;
    public Animator anim;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            if (!isAttacking)
            {
                isAttacking = true;
                anim.SetBool("IsAttacking", isAttacking);
            }
            else
            {
                if (isAttacking)
                {
                    isAttacking = false;
                    anim.SetBool("IsAtacking", isAttacking);
                    StopMoving();
                }
            }

        }

        void Shoot()
        {
            Debug.Log("Shot Projectile");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 firePoint2D = new Vector2(firePoint.position.x, firePoint.position.y);
            Vector2 aimDirection = mousePos - firePoint2D;

            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion radialPosition = Quaternion.Euler(0, 0, angle);
            firePoint.rotation = radialPosition;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    private void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce;
    public float fireRate;

    public AudioSource shootSFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

            //Cancel any Shoot() method code execution  
            CancelInvoke("Shoot");
        }

        //while the "Fire1" button is being held down  
        if (Input.GetButton("Fire1") && !IsInvoking("Shoot"))
        {
            Hold();
        }

        //If the "Fire1" has been released, cancel any scheduled Shoot() method executions  
        if (Input.GetButtonUp("Fire1"))
        {
            //Cancel any Shoot() method code execution  
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        shootSFX.Play();
    }

    void Hold()
    {
        Invoke("Shoot", fireRate);
    }
}

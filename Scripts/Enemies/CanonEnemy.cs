using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce;
    public float timeBtwShots;
    public float startTimeBtwShots;

    public int health;

    public Vector2 movement;

    private Rigidbody2D rb;

    public Transform target;

    public string aimAt;

    public bool playerInRange;

    public GameObject deathEffect;

    //SFX
    public AudioSource shootSFX;
    public GameObject destroyedSFX;

    //Boss
    public bool isBoss;
    public GameObject stairs;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(aimAt).GetComponent<Transform>();

        rb = this.GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true)
        {
            Vector3 directrion = target.position - transform.position;
            float angle = Mathf.Atan2(directrion.y, directrion.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            movement = directrion;

            if (timeBtwShots <= 0)
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (health <= 0 && isBoss)
        {
            Instantiate(destroyedSFX, transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            stairs.SetActive(true);
        }
        else if (health <= 0)
        {
            Instantiate(destroyedSFX, transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }
    

    void Shoot()
    {
        shootSFX.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health--;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}

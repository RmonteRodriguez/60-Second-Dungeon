using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumboJellyfish : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;

    public Rigidbody2D rb;

    public bool isWalking;

    private int walkDirection;

    public GameObject projectile;

    public Transform currentLocation;
    public new Vector3 spawnPoint;

    public GameObject deathEffect;

    //Boss
    public bool isBoss;
    public GameObject stairs;

    //SFX
    public GameObject destroyedSFX;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;
        moveSpeed = 2;

        ChooseDirection();
    }

    void Update()
    {
        spawnPoint = transform.position;

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    break;
                case 4:
                    rb.velocity = new Vector2(-moveSpeed, moveSpeed);
                    break;
                case 5:
                    rb.velocity = new Vector2(moveSpeed, -moveSpeed);
                    break;
                case 6:
                    rb.velocity = new Vector2(moveSpeed, moveSpeed);
                    break;
                case 7:
                    rb.velocity = new Vector2(-moveSpeed, -moveSpeed);
                    break;
            }

            if (walkCounter < 0)
            {
                waitTime = Random.Range(0, 3);
                moveSpeed = Random.Range(0, 2);
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            rb.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
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

    public void ChooseDirection()
    {
        walkTime = Random.Range(0, 3);
        walkDirection = Random.Range(0, 9);
        isWalking = true;
        walkCounter = walkTime;
    }

    public void Shoot()
    {
        Instantiate(projectile, spawnPoint, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health--;
        }
    }
}

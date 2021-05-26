using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningSkullEnemy : MonoBehaviour
{
    public float speed;
    private Transform target;

    public int health;

    public string follow;

    public bool playerInRange = false;

    public Vector2 movement;

    private Rigidbody2D rb;

    public GameObject deathEffect;

    //SFX
    public GameObject destroyedSFX;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(follow).GetComponent<Transform>();

        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true)
        {
            Vector3 directrion = target.position - transform.position;
            float angle = Mathf.Atan2(directrion.y, directrion.x) * Mathf.Rad2Deg * 90f;
            rb.rotation = angle;
            movement = directrion;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            speed = speed + 0.1f;
        }

        if (health <= 0)
        {
            Instantiate(destroyedSFX, transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health--;
        }

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(destroyedSFX, transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
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

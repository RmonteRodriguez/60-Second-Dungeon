using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManger;

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Sprite noSprite;

    Vector2 movement;

    public GameObject deathEffect;

    //SFX
    public AudioSource takeDamage;
    public AudioSource destroyed;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("ManagerGame").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (gameManger.playerHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            destroyed.Play();
            Destroy(gameObject);
            SceneManager.LoadScene(8);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            CameraShake.Instance.ShakeCamera(2f, .1f);
            takeDamage.Play();
            gameManger.playerHealth--;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            CameraShake.Instance.ShakeCamera(2f, .1f);
            takeDamage.Play();
            gameManger.playerHealth--;
        }
    }
}

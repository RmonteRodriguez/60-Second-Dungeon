using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject destroyedSFX;
    public GameObject deathEffect;
    public bool isEntity;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isEntity)
        {
            Instantiate(destroyedSFX, transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}

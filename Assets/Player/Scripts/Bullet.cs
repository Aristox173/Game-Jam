using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 1.0f;

    private float destroyTime;

    void Start()
    {
        destroyTime = Time.time + life;
    }

    void Update()
    {
        if (Time.time >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is not the bullet itself
        if (collision.gameObject != gameObject)
        {
            Destroy(collision.gameObject);
        }

        // Always destroy the bullet
        Destroy(gameObject);
    }
}
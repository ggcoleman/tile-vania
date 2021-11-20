using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float movementSpeed = 1.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }


    void Update()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag != "Player")
        {
            movementSpeed = -movementSpeed;
            FlipEnemyDirection();
        }
    }

    void FlipEnemyDirection()
    {

        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }
}

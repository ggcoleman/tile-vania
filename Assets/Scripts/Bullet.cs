using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float bulletSpeed;
    Rigidbody2D rb;
    PlayerMovement player; 
    float xSpeed;

    CircleCollider2D bulletCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>(); 
        bulletCollider = GetComponent<CircleCollider2D>();
    }


    void Start()
    {
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (bulletCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(gameObject);
        }
    }

}

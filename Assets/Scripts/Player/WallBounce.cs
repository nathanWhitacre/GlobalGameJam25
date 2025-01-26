
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    public float bounceForce;

    private Vector2 prevVelocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        prevVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // The players can bounce off the walls
        if (collision.gameObject.tag == "Wall")
        {
            Vector2 normal = collision.GetContact(0).normal;
            if (normal.x != 0)
            {
                rb.velocity = (new Vector2(-prevVelocity.x, rb.velocity.y)) * bounceForce;
            } else
            {
                rb.velocity = (new Vector2(rb.velocity.x, -prevVelocity.y)) * bounceForce;
            }
        }
    }
}

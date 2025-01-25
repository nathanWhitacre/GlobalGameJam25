
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bounce : MonoBehaviour
{
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
            Debug.Log(prevVelocity);
            if (normal.x != 0)
            {
                rb.velocity = new Vector2(-prevVelocity.x, rb.velocity.y);
            } else
            {
                rb.velocity = new Vector2(rb.velocity.x, -prevVelocity.y);
            }
        }

        // The players can bounce off of each other
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D otherRd = collision.gameObject.GetComponent<Rigidbody2D>();

        }
    }
}

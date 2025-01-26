using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float accel;
    public float decel;
    public float maxSpeed;

    private Vector2 velocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // use accel when input velocity and rigidbody velocity are in the same direction
        // and use decel otherwise
        int horizontalAccel;
        if (velocity.x == 0) horizontalAccel = 0;
        else horizontalAccel = (int) Mathf.Sign(velocity.x * rb.velocity.x);
        int verticalAccel;
        if (velocity.y == 0) verticalAccel = 0;
        else verticalAccel = (int) Mathf.Sign(velocity.y * rb.velocity.y);

        Vector2 addVelocity = Vector2.zero;
        if (horizontalAccel != 0)
        {
            if (horizontalAccel > 0)
            {
                if (rb.velocity.magnitude < maxSpeed)
                {
                    addVelocity += (velocity.x > 0) ? new Vector2(accel, 0) : new Vector2(-accel, 0);
                }
            } else
            {
                addVelocity += (velocity.x > 0) ? new Vector2(decel, 0) : new Vector2(-decel, 0);
            }
        }
        if (verticalAccel != 0) 
        {
            if (verticalAccel > 0)
            {
                if (rb.velocity.magnitude < maxSpeed)
                {
                    addVelocity += (velocity.y > 0) ? new Vector2(0, accel) : new Vector2(0, -accel);
                }
            } else
            {
                addVelocity += (velocity.y > 0) ? new Vector2(0, decel) : new Vector2(0, -decel);
            }
        }

        rb.velocity += addVelocity * Time.deltaTime;
    }

    /// Player Movement
    public void movement(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>();
    }
}

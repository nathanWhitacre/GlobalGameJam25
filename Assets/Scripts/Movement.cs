using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float accel;
    public float decel;
    private Vector2 velocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // use accel when input velocity and rigidbody velocity are in the same direction
        // and use decel otherwise
        int horizontalAccel;
        if (velocity.x == 0) horizontalAccel = 0;
        else horizontalAccel = (int) Mathf.Sign(velocity.x * rb.velocity.x);
        int verticalAccel;
        if (velocity.y == 0) verticalAccel = 0;
        else verticalAccel = (int) Mathf.Sign(velocity.y * rb.velocity.y);

        Debug.Log(string.Format("hAccel: {0}", horizontalAccel));
        Debug.Log(string.Format("vAccel: {0}", verticalAccel));

        Vector2 addVelocity = Vector2.zero;
        if (horizontalAccel != 0) {
            if (velocity.x > 0) {
                addVelocity += (horizontalAccel > 0) ? new Vector2(accel, 0) : new Vector2(decel, 0);
            } else
            {
                addVelocity += (horizontalAccel > 0) ? new Vector2(-accel, 0) : new Vector2(-decel, 0);
            }
        }
        if (verticalAccel != 0) {
            if (velocity.y > 0) {
                addVelocity += (verticalAccel > 0) ? new Vector2(0, accel) : new Vector2(0, decel);
            } else
            {
                addVelocity += (verticalAccel > 0) ? new Vector2(0, -accel) : new Vector2(0, -decel);
            }
        }

        // Debug.Log(addVelocity);

        rb.velocity += addVelocity * Time.deltaTime;
    }

    /// Player Movement
    public void movement(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>();
    }
}

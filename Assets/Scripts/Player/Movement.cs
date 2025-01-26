using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Jobs;

public class Movement : MonoBehaviour
{
    public float accel;
    public float decel;
    public float noInputDecel;
    public float maxSpeed;
    public float deadTransparency;

    private bool restart;
    private Vector2 velocity;
    private Transform spriteTransform;
    private SpriteRenderer faceSprite;
    private Rigidbody2D rb;
    [SerializeField] Sprite[] faceSprites;

    // Start is called before the first frame update
    void Start()
    {
        restart = true;
        rb = GetComponent<Rigidbody2D>();
        faceSprite = transform.GetChild(2).GetComponent<SpriteRenderer>();
        spriteTransform = transform.GetChild(2).GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (!restart && GetComponent<Health>().dead)
        {
            changeFace();
            restart = true;
        }
        if (restart && !GetComponent<Health>().dead)
        {
            changeFace();
            restart = false;
        }
        positionFace();

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

        // If there's no input, use noInputDecel
        if (verticalAccel == 0 && horizontalAccel == 0)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, noInputDecel * Time.deltaTime);
        }
        else
        {
            rb.velocity += addVelocity * Time.deltaTime;
        }
    }

    /// Player Movement
    public void movement(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Changes faces of the players accordingly
    /// </summary>
    private void changeFace()
    {
        SpriteRenderer bubbleSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Color bubbleColor = bubbleSprite.color;
        Color faceColor = faceSprite.color;
        if (GetComponent<Health>().dead)
        {
            faceSprite.sprite = faceSprites[0];
            bubbleColor.a = deadTransparency;
            faceColor.a = deadTransparency;
        }
        else
        {
            faceSprite.sprite = faceSprites[Random.Range(1,10)];
            bubbleColor.a = 1f;
            faceColor.a = 1f;
        }
        bubbleSprite.color = bubbleColor;
        faceSprite.color = faceColor;
    }

    /// <summary>
    /// Positions the face of the player based on its movement
    /// </summary>
    private void positionFace()
    {
        if (GetComponent<Health>().dead)
        {
            spriteTransform.localPosition = -rb.velocity / maxSpeed / 3;
            if (rb.velocity != Vector2.zero)
            {
                if (rb.velocity.x > 0)
                {
                    faceSprite.flipX = true;
                }
                else
                {
                    faceSprite.flipX = false;
                }
            }
        }
        else
        {
            spriteTransform.localPosition = rb.velocity / maxSpeed / 3;
            if (rb.velocity != Vector2.zero)
            {
                if (rb.velocity.x > 0)
                {
                    faceSprite.flipX = false;
                }
                else
                {
                    faceSprite.flipX = true;
                }
            }
        }
    }
}

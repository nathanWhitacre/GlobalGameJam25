using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    public float bounceForce;

    [SerializeField] private Rigidbody2D rb1;
    [SerializeField] private Rigidbody2D rb2;
    private Vector2 prevVelocity1;
    private Vector2 prevVelocity2;

    void FixedUpdate()
    {
        prevVelocity1 = rb1.velocity;
        prevVelocity2 = rb2.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // The players can bounce off of each other
        if (collision.gameObject.tag == "Player")
        {
            Vector2 normal = collision.GetContact(0).normal;
            float speed1 = prevVelocity1.magnitude;
            float speed2 = prevVelocity2.magnitude;

            float angle1 = Vector2.SignedAngle(-prevVelocity1, normal);
            //Vector2 newDir1 = Quaternion.AngleAxis(2 * angle1, Vector3.forward) * -prevVelocity1;

            float angle2 = Vector2.SignedAngle(-prevVelocity2, -normal);
            //Vector2 newDir2 = Quaternion.AngleAxis(2 * angle2, Vector3.forward) * -prevVelocity2;

            Debug.Log(string.Format("angle1: {0} {1} {2}", angle1, -prevVelocity1, normal));
            Debug.Log(string.Format("angle2: {0} {1} {2}", angle2, -prevVelocity2, -normal));

            // Rotate the system such that the players bounce off each other via the y-axis
            // speed1 * cos(angle1) + (-speed2) * cos(angle2) = v_1xf + v_2xf
            // v_1xf - v_2xf = speed1 * cos(angle1) - (-speed2) * cos(angle2)
            // v_1xf = speed1 * cos(angle1), v_2xf = speed2 * cos(angle2)
            // 
            float v_1xf = speed1 * Mathf.Cos(Mathf.Deg2Rad * angle1);
            float v_2xf = speed2 * Mathf.Cos(Mathf.Deg2Rad * angle2);
            float v_1yf = speed1 * Mathf.Sin(Mathf.Deg2Rad * angle1);
            float v_2yf = speed2 * Mathf.Sin(Mathf.Deg2Rad * angle2);
            Vector2 psuedoVector1 = new Vector2(v_1xf, v_1yf);
            Vector2 psuedoVector2 = new Vector2(v_2xf, v_2yf);
            float systemAngle = Vector2.SignedAngle(normal, Vector2.left);
            Vector2 vVector1 = Quaternion.AngleAxis(systemAngle, Vector3.forward) * psuedoVector1;
            Vector2 vVector2 = Quaternion.AngleAxis(systemAngle, Vector3.forward) * psuedoVector2;

            //rb1.velocity = newDir1 * bounceForce;
            //rb2.velocity = newDir2 * bounceForce;
            rb1.velocity = vVector1 * bounceForce;
            rb2.velocity = vVector2 * bounceForce;
        }
    }

    private float getPsuedoAngle()
    {

        return 0;
    }

    // Gets the x velocity for player 1
    private float xVelocity1()
    {

        return 0;
    }
}

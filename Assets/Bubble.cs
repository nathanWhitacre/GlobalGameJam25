using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    [SerializeField] public Rigidbody2D rigidBody;
    [HideInInspector] public float swimSpeed = 0f;
    [HideInInspector] public GameObject playerTarget;
    [SerializeField] public float succSpeed = 0f;
    [SerializeField] public float succAcceleration = 1f;
    [HideInInspector] public bool isSuccing = false;

    // Start is called before the first frame update
    void Start()
    {
        //swimSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSuccing)
        {
            succSpeed += succAcceleration * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        /*
        if (isSuccing && playerTarget != null)
        {
            //rigidBody.velocity = Vector3.zero;
            //transform.position = Vector3.MoveTowards(transform.TransformPoint(transform.position), playerTarget.transform.position, succSpeed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.TransformPoint(transform.position), playerTarget.transform.position, 1f);
            Vector3 targetDirection = (playerTarget.transform.position - transform.position).normalized;
            rigidBody.velocity = targetDirection * succSpeed;
            return;
        }
        */

        Vector2 targetDirection = (isSuccing && playerTarget != null) ? ((playerTarget.transform.position - transform.position).normalized * succSpeed) : Vector2.zero;


        //It GO
        rigidBody.velocity = targetDirection + (new Vector2(swimSpeed, -1 * transform.parent.GetComponent<ItemRow>().rowSpeed));
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bubble Got! " + collision.gameObject.name);

            PointsHandler pointsHandler = FindObjectOfType<PointsHandler>();
            pointsHandler.points += pointsHandler.multiplier;
            Destroy(gameObject);
        }
    }
    */

}

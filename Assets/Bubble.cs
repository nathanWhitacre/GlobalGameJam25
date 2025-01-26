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
        Vector2 targetDirection = (isSuccing && playerTarget != null) ? ((playerTarget.transform.position - transform.position).normalized * succSpeed) : Vector2.zero;
        //It GO
        rigidBody.velocity = targetDirection + (new Vector2(swimSpeed, -1 * transform.parent.GetComponent<ItemRow>().rowSpeed));
    }

}

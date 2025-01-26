using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{

    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public float swimSpeed;

    [HideInInspector] public bool isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        isLeft = (transform.position.x < 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //It GO
        rigidBody.velocity = new Vector2(((isLeft) ? swimSpeed : (-1 * swimSpeed)), -1 * transform.parent.GetComponent<ItemRow>().rowSpeed);
    }
}

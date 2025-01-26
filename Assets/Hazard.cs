using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Somethin Hit! " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit! " + collision.gameObject.name);
        }
    }
}

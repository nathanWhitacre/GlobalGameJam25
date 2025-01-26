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
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit! " + collision.gameObject.name);
            //Destroy(collision.gameObject);
            
            /*
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                if (collision.gameObject.GetComponent<Health>().health > 0)
                {
                    collision.gameObject.GetComponent<Health>().health -= 1;
                    return;
                }
            }
            if (collision.transform.parent.gameObject.GetComponent<Health>().health > 0)
            {
                collision.transform.parent.gameObject.GetComponent<Health>().health -= 1;
            }
            return;
            */

            if (collision.gameObject.layer == 0 ||
                (collision.transform.parent.gameObject.GetComponent<Health>() != null && collision.transform.parent.gameObject.GetComponent<Health>().dead))
            {
                return;
            }
            collision.transform.parent.gameObject.GetComponent<Health>().health -= 1;
        }

        if (collision.gameObject.tag == "Item")
        {
            if (collision.gameObject.GetComponent<BubbleEat>() != null)
            {
                Destroy(collision.transform.parent.gameObject);
                return;
            }
            //Debug.Log("Item Hit! " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

}

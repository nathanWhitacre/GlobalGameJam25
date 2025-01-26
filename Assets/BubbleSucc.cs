using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSucc : MonoBehaviour
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
            Bubble bubble = transform.parent.gameObject.GetComponent<Bubble>();
            bubble.playerTarget = collision.gameObject;
            bubble.isSuccing = true;
        }
    }
}

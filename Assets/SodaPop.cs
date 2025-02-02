using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaPop : MonoBehaviour
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
            if (collision.gameObject.layer == 0 ||
                (collision.transform.parent.gameObject.GetComponent<Health>() != null && collision.transform.parent.gameObject.GetComponent<Health>().dead))
            {
                return;
            }
            //Debug.Log("SodaPop Got! " + collision.gameObject.name);
            PointsHandler pointsHandler = FindObjectOfType<PointsHandler>();
            //pointsHandler.multiplier = Mathf.CeilToInt(((float) pointsHandler.multiplier) * 1.5f);
            pointsHandler.setMultiplier(Mathf.CeilToInt(((float)pointsHandler.multiplier) * 1.5f));
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRow : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] public float rowSpeed = 1f;
    [SerializeField] public int hazardSpawnPercent = 20;
    [SerializeField] public GameObject hazard;
    [SerializeField] public List<GameObject> items;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 10f, 0f);
        items = new List<GameObject>(new GameObject[9]);
        for (int i = 0; i < 9; i++)
        {
            if (Random.Range(1, 100) <= hazardSpawnPercent)
            {
                float xPosition = -8f + (i * 2f);
                items[i] = Instantiate(hazard, new Vector3(xPosition, transform.position.y, 0f), transform.rotation, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(0f, -1 * rowSpeed);
    }
}

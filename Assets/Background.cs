using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] public ItemRowSpawner itemRowSpawner;
    [SerializeField] public PointsHandler pointsHandler;
    [SerializeField] public LineRenderer lineRenderer;
    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public float seaLineDepth = 50f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.endWidth = 20f;
        lineRenderer.startWidth = 20f;
    }

    void FixedUpdate()
    {
        if (pointsHandler.depth <= seaLineDepth)
        {
            lineRenderer.SetPosition(0, lineRenderer.GetPosition(0) + (new Vector3(0f, -1 * itemRowSpawner.rowSpeed, 0f) * 0.03f));
            lineRenderer.SetPosition(1, lineRenderer.GetPosition(1) + (new Vector3(0f, -1 * itemRowSpawner.rowSpeed, 0f) * 0.03f));
            //rigidBody.velocity = new Vector2(0f, -1 * itemRowSpawner.rowSpeed);
        }

        
        if (lineRenderer.GetPosition(1).y < -10f)
        {
            Destroy(gameObject);
        }
        
    }
}

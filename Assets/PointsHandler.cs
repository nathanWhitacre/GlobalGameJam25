using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI pointsText;
    [SerializeField] public TextMeshProUGUI depthText;

    [SerializeField] public int points = 0;
    [SerializeField] public int multiplier = 1;
    [SerializeField] public float depth = -500f;
    [SerializeField] public float depthIncreaseRate = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();

        depth += depthIncreaseRate * Time.deltaTime;
        depthText.text = Mathf.FloorToInt(depth).ToString();
    }
}

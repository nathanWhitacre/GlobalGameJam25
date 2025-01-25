using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowHandler : MonoBehaviour
{

    [SerializeField] public GameObject hazard;
    [SerializeField] public GameObject bubble;
    [SerializeField] public GameObject sodaPop;
    [SerializeField] public GameObject bubbleBath;

    public List<int> newRow = new List<int>();
    public List<int> previousRow = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

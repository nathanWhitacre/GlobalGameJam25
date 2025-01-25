using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ItemRowSpawner : MonoBehaviour
{

    [SerializeField] public int spawnHeight = 10;
    [SerializeField] public float rowSpeed = 1f;
    [SerializeField] public int hazardSpawnPercent = 20;
    [SerializeField] public GameObject itemRow;
    private GameObject previousRow;

    // Start is called before the first frame update
    void Start()
    {
        spawnRow();
    }

    // Update is called once per frame
    void Update()
    {
        if (previousRow == null)
        {
            return;
        }

        if (previousRow.transform.position.y <= (spawnHeight - 2))
        {
            spawnRow();
        }
    }


    public void spawnRow()
    {
        previousRow = Instantiate(itemRow, new Vector3(0f, spawnHeight, 0f), transform.rotation);
        ItemRow row = previousRow.GetComponent<ItemRow>();
        row.rowSpeed = rowSpeed;
        row.hazardSpawnPercent = hazardSpawnPercent;
    }
}

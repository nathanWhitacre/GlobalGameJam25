using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ItemRowSpawner : MonoBehaviour
{

    [SerializeField] public GameObject itemRow;
    [SerializeField] public int spawnHeight = 10;

    [Header("")]
    [SerializeField] public float rowSpeed = 1f;
    [SerializeField] public float speedIncreaseRate = 0.1f;
    [SerializeField] public float maxRowSpeed = 8f;

    [Header("")]
    [SerializeField] public float hazardSpawnPercent = 20f;
    [SerializeField] public float hazardSpawnIncreaseRate = 0.1f;
    [SerializeField] public float maxHazardSpawnPercent = 20f;

    [Header("")]
    [SerializeField] public float smallHazardSpawnPercent = 20f;
    [SerializeField] public float smallHazardSpawnIncreaseRate = 0.1f;
    [SerializeField] public float maxSmallHazardSpawnPercent = 20f;

    [Header("")]
    [SerializeField] public float bubbleSpawnPercent = 20f;
    [SerializeField] public float bubbleSpawnIncreaseRate = 0.1f;
    [SerializeField] public float maxBubbleSpawnPercent = 20f;

    [Header("")]
    [SerializeField] public float fishSpawnPercent = 20f;
    [SerializeField] public float fishSpawnIncreaseRate = 0.1f;
    [SerializeField] public float maxFishSpawnPercent = 20f;

    [HideInInspector] public GameObject currentRow;
    [HideInInspector] public GameObject previousRow;

    // Start is called before the first frame update
    void Start()
    {
        spawnRow();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRow == null)
        {
            return;
        }

        if (currentRow.transform.position.y <= (spawnHeight - 2))
        {
            spawnRow();
        }

        rowSpeed += (rowSpeed >= maxRowSpeed) ? 0f : speedIncreaseRate * Time.deltaTime;
        hazardSpawnPercent += (hazardSpawnPercent >= maxHazardSpawnPercent) ? 0f : hazardSpawnIncreaseRate * Time.deltaTime;
        smallHazardSpawnPercent += (smallHazardSpawnPercent >= maxSmallHazardSpawnPercent) ? 0f : smallHazardSpawnIncreaseRate * Time.deltaTime;
        bubbleSpawnPercent += (bubbleSpawnPercent >= maxBubbleSpawnPercent) ? 0f : bubbleSpawnIncreaseRate * Time.deltaTime;
        fishSpawnPercent += (fishSpawnPercent >= maxFishSpawnPercent) ? 0f : fishSpawnIncreaseRate * Time.deltaTime;
    }


    public void spawnRow()
    {
        previousRow = currentRow;
        currentRow = Instantiate(itemRow, new Vector3(0f, spawnHeight, 0f), transform.rotation, transform);
        ItemRow row = currentRow.GetComponent<ItemRow>();
    }
}

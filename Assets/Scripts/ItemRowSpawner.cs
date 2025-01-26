using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ItemRowSpawner : MonoBehaviour
{

    [SerializeField] public Health player1Health;
    [SerializeField] public Movement player1Movement;
    [SerializeField] public Health player2Health;
    [SerializeField] public Movement player2Movement;

    [Header("")]
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

    [Header("")]
    [SerializeField] public float sodaSpawnPercent = 20f;
    [SerializeField] public float sodaSpawnIncreaseRate = 0.1f;
    [SerializeField] public float maxSodaSpawnPercent = 20f;

    [Header("")]
    [SerializeField] public float bathSpawnPercent = 20f;
    [SerializeField] public float bathSpawnIncreaseRate = 0.1f;
    [SerializeField] public float maxBathSpawnPercent = 20f;
    [HideInInspector] public bool isInBath = false;

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

        if (player1Health.dead && player2Health.dead)
        {
            rowSpeed = 0f;
            speedIncreaseRate = 0f;
            maxRowSpeed = 0f;
            player1Movement.accel = 0f;
            player1Movement.decel = 0f;
            player1Movement.noInputDecel = 10f;
            player1Movement.maxSpeed = 0f;
            player2Movement.accel = 0f;
            player2Movement.decel = 0f;
            player2Movement.noInputDecel = 10f;
            player2Movement.maxSpeed = 0f;
        }

        if (currentRow.transform.position.y <= (spawnHeight - 2))
        {
            spawnRow();
        }

        if (isInBath)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.GetComponent<ItemRow>() != null)
                {
                    transform.GetChild(i).gameObject.GetComponent<ItemRow>().isInBath = true;
                }
            }
            isInBath = false;
        }

        rowSpeed += (rowSpeed >= maxRowSpeed) ? 0f : speedIncreaseRate * Time.deltaTime;
        hazardSpawnPercent += (hazardSpawnPercent >= maxHazardSpawnPercent) ? 0f : hazardSpawnIncreaseRate * Time.deltaTime;
        smallHazardSpawnPercent += (smallHazardSpawnPercent >= maxSmallHazardSpawnPercent) ? 0f : smallHazardSpawnIncreaseRate * Time.deltaTime;
        bubbleSpawnPercent += (bubbleSpawnPercent >= maxBubbleSpawnPercent) ? 0f : bubbleSpawnIncreaseRate * Time.deltaTime;
        fishSpawnPercent += (fishSpawnPercent >= maxFishSpawnPercent) ? 0f : fishSpawnIncreaseRate * Time.deltaTime;
        sodaSpawnPercent += (sodaSpawnPercent >= maxSodaSpawnPercent) ? 0f : sodaSpawnIncreaseRate * Time.deltaTime;
        bathSpawnPercent += (bathSpawnPercent >= maxBathSpawnPercent) ? 0f : bathSpawnIncreaseRate * Time.deltaTime;
    }


    public void spawnRow()
    {
        previousRow = currentRow;
        currentRow = Instantiate(itemRow, new Vector3(0f, spawnHeight, 0f), transform.rotation, transform);
        ItemRow row = currentRow.GetComponent<ItemRow>();
    }
}

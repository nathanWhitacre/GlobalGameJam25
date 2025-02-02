using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemRow : MonoBehaviour
{
    public List<GameObject> fishies;

    [SerializeField] private Rigidbody2D rigidBody;
    [HideInInspector] public float rowSpeed = 1f;

    [HideInInspector] public float hazardSpawnPercent = 20f;
    [SerializeField] public GameObject hazard;

    [HideInInspector] public float smallHazardSpawnPercent = 20f;
    [SerializeField] public GameObject smallHazard;

    [HideInInspector] public float bubbleSpawnPercent = 20f;
    [SerializeField] public GameObject bubble;

    [HideInInspector] public float fishSpawnPercent = 20f;
    [SerializeField] public GameObject fish;
    [SerializeField] public float maxFishSpawnHeight = 5f;
    [SerializeField] public float minFishSpawnHeight = -2f;
    [HideInInspector] public bool isSpawningFish = false;
    [HideInInspector] public float fishSpawnHeight = 0f;
    [HideInInspector] public GameObject spawnedFish;

    [HideInInspector] public float sodaSpawnPercent = 20f;
    [SerializeField] public GameObject soda;

    [HideInInspector] public float bathSpawnPercent = 20f;
    [SerializeField] public GameObject bath;
    [HideInInspector] public bool isInBath = false;

    [HideInInspector] public List<GameObject> items;
    [HideInInspector] public ItemRowSpawner itemRowSpawner;

    // Start is called before the first frame update
    void Start()
    {
        itemRowSpawner = transform.parent.gameObject.GetComponent<ItemRowSpawner>();

        //Set Spawn Rates
        hazardSpawnPercent = itemRowSpawner.hazardSpawnPercent;
        smallHazardSpawnPercent = itemRowSpawner.smallHazardSpawnPercent;
        bubbleSpawnPercent = itemRowSpawner.bubbleSpawnPercent;
        fishSpawnPercent = itemRowSpawner.fishSpawnPercent;
        sodaSpawnPercent = itemRowSpawner.sodaSpawnPercent;
        bathSpawnPercent = itemRowSpawner.bathSpawnPercent;

        //Fish Spawn
        isSpawningFish = false;
        if (Random.Range(1f, 100f) <= fishSpawnPercent)
        {
            isSpawningFish = true;
            fishSpawnHeight = Random.Range(minFishSpawnHeight, maxFishSpawnHeight);
        }

        //Generate Items
        items = new List<GameObject>(new GameObject[9]);
        for (int i = 0; i < items.Count; i++)
        {

            //BubbleBath Spawn
            if (Random.Range(1f, 100f) <= bathSpawnPercent) //Spawn Chance
            {
                //Anti-grouping Override
                if (itemRowSpawner.previousRow != null)
                {
                    List<GameObject> previousItems = itemRowSpawner.previousRow.GetComponent<ItemRow>().items;
                    if (//previousItems[Mathf.Clamp((i - 1), 0, (previousItems.Count - 1))] == null && //Previous Left
                        //items[Mathf.Clamp((i - 1), 0, items.Count - 1)] == null && //Current Left
                        //previousItems[i] == null && //Previous Center
                        //previousItems[Mathf.Clamp((i + 1), 0, previousItems.Count - 1)] == null && //Previous Right
                        true)
                    {
                        //Spawn BubbleBath
                        float xPosition = -8f + (i * 2f);
                        float yPosition = transform.position.y + Random.Range(-0.25f, 0.25f);
                        items[i] = Instantiate(bath, new Vector3(xPosition, yPosition, 0f), transform.rotation, transform);
                        continue;
                    }

                }
            }

            //SodaPop Spawn
            if (Random.Range(1f, 100f) <= sodaSpawnPercent) //Spawn Chance
            {
                //Anti-grouping Override
                if (itemRowSpawner.previousRow != null)
                {
                    List<GameObject> previousItems = itemRowSpawner.previousRow.GetComponent<ItemRow>().items;
                    if (//previousItems[Mathf.Clamp((i - 1), 0, (previousItems.Count - 1))] == null && //Previous Left
                        //items[Mathf.Clamp((i - 1), 0, items.Count - 1)] == null && //Current Left
                        //previousItems[i] == null && //Previous Center
                        //previousItems[Mathf.Clamp((i + 1), 0, previousItems.Count - 1)] == null && //Previous Right
                        true)
                    {
                        //Spawn SodaPop
                        float xPosition = -8f + (i * 2f);
                        float yPosition = transform.position.y + Random.Range(-0.25f, 0.25f);
                        items[i] = Instantiate(soda, new Vector3(xPosition, yPosition, 0f), transform.rotation, transform);
                        continue;
                    }

                }
            }

            //Bubble Spawn
            if (Random.Range(1f, 100f) <= bubbleSpawnPercent) //Spawn Chance
            {
                //Anti-grouping Override
                if (itemRowSpawner.previousRow != null)
                {
                    List<GameObject> previousItems = itemRowSpawner.previousRow.GetComponent<ItemRow>().items;
                    if (//previousItems[Mathf.Clamp((i - 1), 0, (previousItems.Count - 1))] == null && //Previous Left
                        //items[Mathf.Clamp((i - 1), 0, items.Count - 1)] == null && //Current Left
                        //previousItems[i] == null && //Previous Center
                        //previousItems[Mathf.Clamp((i + 1), 0, previousItems.Count - 1)] == null && //Previous Right
                        true)
                    {
                        //Spawn Bubble
                        float xPosition = -8f + (i * 2f) + Random.Range(-1f, 1f);
                        float yPosition = transform.position.y + Random.Range(-1f, 1f);
                        items[i] = Instantiate(bubble, new Vector3(xPosition, yPosition, 0f), transform.rotation, transform);
                        continue;
                    }

                }
            }

            //Hazard Spawn
            if (!isSpawningFish && Random.Range(1f, 100f) <= hazardSpawnPercent) //Spawn Chance
            {
                //Anti-grouping Override
                if (itemRowSpawner.previousRow != null)
                {
                    List<GameObject> previousItems = itemRowSpawner.previousRow.GetComponent<ItemRow>().items;
                    if (previousItems[Mathf.Clamp((i-1), 0, (previousItems.Count-1))] == null && //Previous Left
                        items[Mathf.Clamp((i-1), 0, items.Count-1)] == null && //Current Left
                        previousItems[i] == null && //Previous Center
                        previousItems[Mathf.Clamp((i+1), 0, previousItems.Count-1)] == null && //Previous Right
                        true)
                    {
                        //Spawn Hazard
                        float xPosition = -8f + (i * 2f);
                        items[i] = Instantiate(hazard, new Vector3(xPosition, transform.position.y + Random.Range(-0.25f, 0.25f), 0f), transform.rotation, transform);
                        continue;
                    }
                    
                }
            }

            //Small Hazard Spawn
            if (!isSpawningFish && Random.Range(1f, 100f) <= smallHazardSpawnPercent) //Spawn Chance
            {
                //Anti-grouping Override
                if (itemRowSpawner.previousRow != null)
                {
                    //Left Hazard
                    if (Random.Range(0, 2) == 0)
                    {
                        List<GameObject> previousItems = itemRowSpawner.previousRow.GetComponent<ItemRow>().items;
                        if (i != 0 && //Wall Current left
                            previousItems[Mathf.Clamp((i - 1), 0, (previousItems.Count - 1))] == null && //Previous Left
                            items[Mathf.Clamp((i - 1), 0, items.Count - 1)] == null && //Current Left
                            previousItems[i] == null && //Previous Center
                            //previousItems[Mathf.Clamp((i + 1), 0, previousItems.Count - 1)] == null && //Previous Right
                            true)
                        {
                            //Spawn Small Hazard
                            float xPosition = -9f + (i * 2f);
                            items[i] = Instantiate(smallHazard, new Vector3(xPosition, transform.position.y + Random.Range(-0.25f, 0.25f), 0f), transform.rotation, transform);
                            continue;
                        }
                    }
                    //Right Hazard
                    else
                    {
                        List<GameObject> previousItems = itemRowSpawner.previousRow.GetComponent<ItemRow>().items;
                        if (i != (items.Count-1) && //Wall Current left
                            //previousItems[Mathf.Clamp((i - 1), 0, (previousItems.Count - 1))] == null && //Previous Left
                            items[Mathf.Clamp((i - 1), 0, items.Count - 1)] == null && //Current Left
                            previousItems[i] == null && //Previous Center
                            previousItems[Mathf.Clamp((i + 1), 0, previousItems.Count - 1)] == null && //Previous Right
                            true)
                        {
                            //Spawn Small Hazard
                            float xPosition = -7f + (i * 2f);
                            items[i] = Instantiate(smallHazard, new Vector3(xPosition, transform.position.y + Random.Range(-0.25f, 0.25f), 0f), transform.rotation, transform);
                            continue;
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Set Speed
        if (itemRowSpawner != null)
        {
            rowSpeed = itemRowSpawner.rowSpeed;
        }

        //Destroy Row
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }

        //Spawn Fish
        if (isSpawningFish && transform.position.y < fishSpawnHeight)
        {
            isSpawningFish = false;
            float xPosition = -10f;
            if (Random.Range(0, 2) == 0)
            {
                xPosition = Mathf.Abs(xPosition);
            }
            int fishIndex = Random.Range(0, fishies.Count);
            spawnedFish = Instantiate(fishies[fishIndex], new Vector3(xPosition, transform.position.y, 0f), transform.rotation, transform);
        }

        //Bubble Bath
        if (isInBath)
        {
            isInBath = false;

            if (spawnedFish != null && spawnedFish.GetComponent<Bubble>() == null)
            {
                Vector3 fishPosition = spawnedFish.transform.position;
                Vector2 fishVelocity = spawnedFish.GetComponent<Rigidbody2D>().velocity;
                Destroy(spawnedFish);
                spawnedFish = Instantiate(bubble, new Vector3(fishPosition.x, transform.position.y, 0f), transform.rotation, transform);
                spawnedFish.GetComponent<Bubble>().swimSpeed = fishVelocity.x;
            }
            
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] != null && items[i].GetComponent<Bubble>() == null)
                {
                    Vector3 itemPosition = items[i].transform.position;
                    Destroy(items[i]);
                    items[i] = Instantiate(bubble, new Vector3(itemPosition.x, transform.position.y, 0f), transform.rotation, transform);
                }
            }
            
        }
    }

    void FixedUpdate()
    {
        //It GO
        rigidBody.velocity = new Vector2(0f, -1 * rowSpeed);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    float timeBtwSpawn;
    [SerializeField] [Range(0.1f, 10f)] float startTimeMin = 1f;
    [SerializeField] [Range(1f, 10f)] float startTimeMax = 10f;
    [SerializeField] [Range(0f, 1f)] float deltaTimeMod = 0.001f;
    [SerializeField] [Range(0, 10000)] float distanceToStartSpawn = 0f;
    private void Start()
    {
        timeBtwSpawn = Random.Range(startTimeMin, startTimeMax);
    }
    void Update()
    {
        if (ScoreManager.Distance >= distanceToStartSpawn)
        {
            if (timeBtwSpawn <= 0)
            {
                GenarateItem();
                if (startTimeMin > 0.01)
                {
                    startTimeMin -= deltaTimeMod;
                    startTimeMax -= deltaTimeMod;
                }
                timeBtwSpawn = Random.Range(startTimeMin, startTimeMax);
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }

    public void GenarateItem()
    {
        Instantiate(itemPrefab, transform.position + Random.insideUnitSphere, Quaternion.identity, transform);
    }
}

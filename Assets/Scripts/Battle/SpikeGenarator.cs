//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenarator : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    [SerializeField] GameObject upgradedPrefab;
    [SerializeField] int minheat = 2;
    float timeBtwSpawn;
    [SerializeField] float startTimeBtwSpawn = 2f;
    [SerializeField] [Range(0f, 1f)] float startTimeDelta = 0.001f;
    [SerializeField] [Range(0.001f, 2f)] float startTimeLimit = 0.1f;
    [SerializeField] [Range(0, 10000)] float distanceToStartSpawn = 0f;

    void Start()
    {
        if (HeatHandler.GetHeatValue(HeatType.StrogerFoes) >= minheat)
        {
            spikePrefab = upgradedPrefab;
        }
        float HeatMod = startTimeBtwSpawn * HeatHandler.GetHeatValue(HeatType.SpawnRate) * 0.05f;
        startTimeBtwSpawn -= HeatMod;
        if (startTimeBtwSpawn <= startTimeLimit)
        {
            startTimeBtwSpawn = startTimeLimit;
        }
    }
    void Update()
    {
        if (ScoreManager.Distance >= distanceToStartSpawn)
        {
            if (timeBtwSpawn <= 0)
            {
                GenarateSpike();
                if (startTimeBtwSpawn > startTimeLimit)
                    startTimeBtwSpawn -= startTimeDelta;
                timeBtwSpawn = startTimeBtwSpawn;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }
    public void GenarateSpike()
    {
        Instantiate(spikePrefab, transform.position + new Vector3(Random.value * -1,0,0), Quaternion.identity, transform);
    }
}

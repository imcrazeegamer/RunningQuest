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
    float lastDistanceMulti = 0;
    [SerializeField] bool useUnitCircle = false;
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
            int dis = (int)(ScoreManager.Distance);
            if (dis % 10 == 0)
                if (startTimeBtwSpawn > startTimeLimit && lastDistanceMulti != dis)
                {
                    lastDistanceMulti = dis;
                    startTimeBtwSpawn -= startTimeDelta;
                    //Debug.Log($"SpawnRate Is Now {startTimeBtwSpawn}");
                }
                    

            if (timeBtwSpawn <= 0)
            {
                GenarateSpike();
                
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
        Vector3 spawnLocation = transform.position + new Vector3(Random.value * -1, 0, 0);
        if (useUnitCircle)
        {
            spawnLocation += Random.insideUnitSphere;
        }
        Instantiate(spikePrefab, spawnLocation, Quaternion.identity, transform);
    }
}

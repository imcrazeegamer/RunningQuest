//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenarator : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    float timeBtwSpawn;
    [SerializeField] float startTimeBtwSpawn = 2f;
    [SerializeField] [Range(0f, 1f)] float startTimeDelta = 0.001f;
    [SerializeField] [Range(0.001f, 2f)] float startTimeLimit = 0.1f;
    [SerializeField] [Range(0, 10000)] float distanceToStartSpawn = 0f;

    void Start()
    {
        startTimeBtwSpawn -= startTimeBtwSpawn * HeatHandler.GetHeatValue(HeatType.SpawnRate) * 0.1f;
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

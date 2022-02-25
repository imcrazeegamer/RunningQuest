//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenarator : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    [SerializeField] [Range(0, 100)] float minSpeed = 1;
    [SerializeField] [Range(0, 100)] float speedDeltaFactor = 0.001f;
    [SerializeField] [Range(1, 100)] float speedLimit = 10f;
    public float currentSpeed;
    float timeBtwSpawn;
    [SerializeField] float startTimeBtwSpawn = 2f;
    [SerializeField] [Range(0f, 1f)] float startTimeDelta = 0.001f;
    [SerializeField] [Range(0.001f, 2f)] float startTimeLimit = 0.1f;
    [SerializeField] [Range(0, 10000)] float distanceToStartSpawn = 0f;
   
    void Awake()
    {
        currentSpeed = minSpeed;
        
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
        SpikeMovment sm;
        if(TryGetComponent(out sm))
        {
            sm.currentSpeed = currentSpeed;
        }
        Instantiate(spikePrefab, transform.position + new Vector3(Random.value * -1,0,0), Quaternion.identity, transform);
        //currentSpeed = Mathf.Log10(currentSpeed + speedDeltaFactor);
        if(currentSpeed < speedLimit)
            currentSpeed += speedDeltaFactor;
    }
}

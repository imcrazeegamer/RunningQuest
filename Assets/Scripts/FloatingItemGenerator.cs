using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    float timeBtwSpawn;
    [SerializeField] float startTimeMin = 1f;
    [SerializeField] float startTimeMax = 10f;
    [SerializeField] float deltaTimeMod = 0.001f;
    private void Start()
    {
        timeBtwSpawn = Random.Range(startTimeMin, startTimeMax);
    }
    void Update()
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

    public void GenarateItem()
    {
        Instantiate(itemPrefab, transform.position + Random.insideUnitSphere, Quaternion.identity, transform);
    }
}

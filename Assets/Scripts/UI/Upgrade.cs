using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public string name;
    public string description;
    public int initalCost;
    [Range(1f, 2f)] public float costMultiplyer;
    public int Level = 0;
    [HideInInspector] public int Cost { get => (int)(initalCost + Mathf.Pow(costMultiplyer, Level)); }
    [HideInInspector] public GameObject instance;
    public int moneySpent()
    {
        int sum = 0;
        for (int i = 0; i < Level; i++)
        {
            sum += ((int)(initalCost + initalCost * costMultiplyer * i));
        }
        return sum;
            
    }
}
public enum UpgradeType
{
    Jumps,
    HpRegen,
    Shield,
    HealItem,
}

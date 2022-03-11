using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float highDistance;
    public ulong schmekels;
    public bool[] unlocks;
    public int[] upgrades;

    public SaveData(float hDistance, ulong schmekels,int[] upgrades)
    {
        this.highDistance = hDistance;
        this.schmekels = schmekels;
        unlocks = new bool[] { false, false, false };
        if (upgrades == null || upgrades.Length == 0)
            upgrades = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        this.upgrades = upgrades;
    }
    public SaveData()
    {
        this.highDistance = 0;
        this.schmekels = 0;
        unlocks = new bool[] { false, false, false };
        upgrades = new int[] { 0, 0, 0 };
    }
}

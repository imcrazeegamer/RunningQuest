using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float highDistance;
    public int schmekels;
    public bool[] unlocks;
    public int[] upgrades;

    public SaveData(float hDistance, int schmekels)
    {
        this.highDistance = hDistance;
        this.schmekels = schmekels;
        unlocks = new bool[] { false, false, false };
        upgrades = new int[] { 0, 0, 0 };
    }
    public SaveData()
    {
        this.highDistance = 0;
        this.schmekels = 0;
        unlocks = new bool[] { false, false, false };
        upgrades = new int[] { 0, 0, 0 };
    }
}

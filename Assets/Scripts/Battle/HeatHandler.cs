using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatHandler : MonoBehaviour
{
    public static int GetHeatValue(HeatType type)
    {
        return ScoreManager.HeatList[(int)type];
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeatSelection : MonoBehaviour
{
    // Start is called before the first frame update
    List<HeatModGUI> heatMods;
    private void Awake()
    {
        heatMods = GetComponentsInChildren<HeatModGUI>().ToList();
    }
    void Start()
    {
        LoadHeatFromData(ScoreManager.HeatList);
    }
    public void LoadHeatFromData(List<int> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            heatMods[i].UpdateObj(data[i]);
        }
    }
    void Update()
    {
        ScoreManager.HeatList = GuiToData();
    }
    public List<int> GuiToData()
    {
        return heatMods.Select(x => x.level).ToList();
    }
}
public enum HeatType
{
    GameSpeed,
    DamageTaken,
    JumpSacrifice,
    HealAmount,
    SpawnRate
}

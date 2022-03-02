using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeatModGUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI modValue;
    public TextMeshProUGUI heatPer;
    public int level = 0;
    public int heatLevel = 0;

    public void ChangeLevel(int delta)
    {
        if (level + delta < 0)
        {
            level = 0;
        }
        else
        {
            level += delta;
        }
        heatLevel = level * Convert.ToInt32(heatPer.text);
        updateModValue();

    }
    void updateModValue()
    {
        
        string ogStr = modValue.text;
        if (ogStr.Contains('%'))
        {
            modValue.text = $"{ogStr[0]}{heatLevel * 10}%";
        }
        else
        {
            modValue.text = $"{ogStr[0]}{level}";
        }
    }

    public void UpdateObj(int level)
    {
        this.level = level;
        ChangeLevel(0);
    }
}

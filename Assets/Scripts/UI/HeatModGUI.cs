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
    public int maxLevel = -1;
    public int level = 0;
    public int delta = 10;

    public void ChangeLevel(int delta)
    {
        if (level + delta < 0)
        {
            level = 0;
        }
        else if (maxLevel != -1 && level + delta > maxLevel)
        {
            level = maxLevel;
        }
        else
        {
            level += delta;
            AudioManager.instance.Play("btnUI");
        }
        updateModValue();

    }
    void updateModValue()
    {
        
        string ogStr = modValue.text;
        if (ogStr.Contains('%'))
        {
            modValue.text = $"{ogStr[0]}{level * delta}%";
        }
        else
        {
            modValue.text = $"{ogStr[0]}{level}";
        }
    }

    public void UpdateObj(int level)
    {
        this.level = level;
        updateModValue();
    }
}

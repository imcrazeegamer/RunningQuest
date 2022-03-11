using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    [SerializeField] int deltaHeat = 20;
    [SerializeField] TextMeshProUGUI titleText;

    List<string> levelNames = new List<string>() 
    {
        "Forest Of The Fall",
        "Jungle Of Nature",
        "Mount Jermon",
        "Dante's Demonic Forest",
        "The Industrial Revolution",
    };


    public void SwitchBackground(int heat)
    {
        
        List<GameObject> Backgrounds = new List<GameObject>();
        foreach (Transform child in transform)
        {
            Backgrounds.Add(child.gameObject);
        }
        int index = (int)(heat / deltaHeat);
        int limit = Backgrounds.Count - 1;
        if (index > limit)
        {
            index = limit;
        }
        for (int i = 0; i < Backgrounds.Count; i++)
        {
            Backgrounds[i].SetActive(index == i);
        }
        titleText.text = $">{levelNames[index]}<";
    }
}

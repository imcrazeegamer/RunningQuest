using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwitchBackground(int heat)
    {
        List<GameObject> Backgrounds = new List<GameObject>();
        foreach (Transform child in transform)
        {
            Backgrounds.Add(child.gameObject);
        }
        int index = (int)(heat / 5);
        int limit = Backgrounds.Count - 1;
        if (index > limit)
        {
            index = limit;
        }
        for (int i = 0; i < Backgrounds.Count; i++)
        {
            Backgrounds[i].SetActive(index == i);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI valueText;
    Slider s;
    void Awake()
    {
        s = GetComponent<Slider>();
    }
    void Update()
    {

        s.maxValue = 1;
        s.value = player.Hp;
        valueText.text = $"{System.Math.Round(player.Hp * 100, 1)}/{100}";
    }
}

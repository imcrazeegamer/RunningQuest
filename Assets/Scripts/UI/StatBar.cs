using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] Player player;
    Slider s;
    void Awake()
    {
        s = GetComponent<Slider>();
    }
    void Update()
    {

        s.maxValue = 1;
        s.value = player.Hp;
    }
}

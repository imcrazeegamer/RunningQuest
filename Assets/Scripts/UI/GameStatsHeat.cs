using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatsHeat : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> stats;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        //Add Stat About Run with that heat if it happen and what was the hi score
        //Add run count
        stats[0].text = $"Heat: {ScoreManager.Heat}";
        stats[1].text = $"Gold Multiplyer: {System.Math.Round(ScoreManager.GoldMulti,3)}";
        stats[2].text = $"Distance Multiplyer: {System.Math.Round(ScoreManager.DistanceMulti,3)}";
    }

}

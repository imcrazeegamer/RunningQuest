using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SchmekelsText;
    [SerializeField] TextMeshProUGUI DistanceText;
    [SerializeField] TextMeshProUGUI HiScoreText;
    [SerializeField] TextMeshProUGUI HeatText;
    private void FixedUpdate()
    {
        SchmekelsText.text = $"Schmekels: {ScoreManager.Schmekels}";
        DistanceText.text = $"Distance: {System.Math.Round(ScoreManager.Distance, 1)}m";
        HiScoreText.text = $"HiScore: {System.Math.Round(ScoreManager.__HiDistance, 2)}m";
        HeatText.text = $"Heat: {ScoreManager.Heat}";
    }
}

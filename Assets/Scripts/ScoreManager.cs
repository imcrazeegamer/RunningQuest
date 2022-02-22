using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static int Schmekels = 0;
    public static float Distance = 0;
    public static float __HiDistance = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI DistanceText;
    [SerializeField] TextMeshProUGUI HiScoreText;
    private void Awake()
    {
        SaveData s = SaveSystem.LoadGame();
        Schmekels = s.schmekels;
        __HiDistance = s.highDistance;
    }
    private void FixedUpdate()
    {
        ScoreText.text = $"Schmekels: {Schmekels}";
        DistanceText.text = $"Distance: {System.Math.Round(Distance, 2)}m";
        HiScoreText.text = $"HiScore: {System.Math.Round(__HiDistance, 2)}m";
    }

    public static void SaveScore()
    {        
        SaveSystem.SaveGame(new SaveData(__HiDistance, Schmekels));
    }
}
